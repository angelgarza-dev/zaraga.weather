using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Dispatching;
using Plugin.Maui.BottomSheet.Navigation;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using zaraga.weather.Converters;
using zaraga.weather.Models;
using zaraga.weather.Pages.Search;
using zaraga.weather.Services;
using zaraga.weather.Views;

namespace zaraga.weather.Pages.Home;

public class HomeViewModel : SharedViewModel
{
    private Location? _lastLocation = null;
    private IDispatcherTimer? timer = null;
    private WeatherCurrentLocation _currentWeather = new();
    private WeatherForecastAstro _currentAstronomy = new();
    private WeatherAlerts _locationAlerts = new();
    private WeatherForecast _currentForecast = new();
    private WeatherForecast _weeklyForecast = new();
    private int _forecastDays = 3;
    private bool _forecastLoading = false;
    private bool _usingSearchLocation = false;
    private SkiaSharp.Extended.UI.Controls.SKLottieImageSource _moonImageSource = (SkiaSharp.Extended.UI.Controls.SKLottieImageSource)SkiaSharp.Extended.UI.Controls.SKLottieImageSource.FromFile($"{App.NotAvailableIcon}.json");
    private SkiaSharp.Extended.UI.Controls.SKLottieImageSource _epaImageSource = (SkiaSharp.Extended.UI.Controls.SKLottieImageSource)SkiaSharp.Extended.UI.Controls.SKLottieImageSource.FromFile($"{App.NotAvailableIcon}.json");
    private SkiaSharp.Extended.UI.Controls.SKLottieImageSource _defraImageSource = (SkiaSharp.Extended.UI.Controls.SKLottieImageSource)SkiaSharp.Extended.UI.Controls.SKLottieImageSource.FromFile($"{App.NotAvailableIcon}.json");


    public WeatherCurrentLocation CurrentWeather { get => _currentWeather; set { _currentWeather = value; OnPropertyChanged(); } }
    public WeatherForecastAstro CurrentAstronomy { get => _currentAstronomy; set { _currentAstronomy = value; OnPropertyChanged(); } }
    public WeatherAlerts LocationAlerts { get => _locationAlerts; set { _locationAlerts = value; OnPropertyChanged(); } }
    public WeatherForecast CurrentForecast { get => _currentForecast; set { _currentForecast = value; OnPropertyChanged(); } }
    public WeatherForecast WeeklyForecast { get => _weeklyForecast; set { _weeklyForecast = value; OnPropertyChanged(); } }
    public int ForecastDays { get => _forecastDays; set { _forecastDays = value; OnPropertyChanged(); } }
    public bool ForecastLoading { get => _forecastLoading; set { _forecastLoading = value; OnPropertyChanged(); } }
    public SkiaSharp.Extended.UI.Controls.SKLottieImageSource MoonImageSource { get => _moonImageSource; set { _moonImageSource = value; OnPropertyChanged(); } }
    public SkiaSharp.Extended.UI.Controls.SKLottieImageSource EpaImageSource { get => _epaImageSource; set { _epaImageSource = value; OnPropertyChanged(); } }
    public SkiaSharp.Extended.UI.Controls.SKLottieImageSource DefraImageSource { get => _defraImageSource; set { _defraImageSource = value; OnPropertyChanged(); } }



    public Command LoadDataCommand => new Command(Init);
    public Command ReloadDataCommand => new Command(async () => await LoadData());
    public Command OnDisapearingCommand => new Command(OnDisapearing);
    public Command OnForecastDaysChangeCommand => new Command(OnForecastDaysChange);
    public Command GoToSettingsCommand => new Command(GoToSettings);
    public Command SearchCommand => new Command(Search);


    public HomeViewModel()
    {

    }

    private void OnDisapearing()
    {

    }

    private async void OnForecastDaysChange()
    {
        //validación para no obtener datos duplicados
        if (IsLoading) return;

        ForecastLoading = true;
        _lastLocation = await GetDeviceLocation();
        if (_lastLocation == null)
        {
            IsLoading = false;
            return;
        }

        await GetWeeklyForecast(_lastLocation);
        ForecastLoading = false;
    }

    /// <summary>
    /// Obtiene los datos iniciales
    /// </summary>
    private async void Init()
    {
        if (_usingSearchLocation)
        {
            return;
        }

        IsLoading = true;
        if (CurrentWeather.location != null)
        {
            CurrentWeather.location.name = "Cargando...";
        }

        //permisos y ubicación actual
        await GetAppPermissions();
        _lastLocation = await GetDeviceLocation();
        if (_lastLocation == null)
        {
            IsLoading = false;
            return;
        }

        await LoadData();
        StartTimer();

        IsLoading = false;
    }

    /// <summary>
    /// Llama a los endpoints para obtener la información a mostrar
    /// </summary>
    /// <returns></returns>
    private async Task LoadData()
    {
        if (_lastLocation == null)
        {
            return;
        }

        IsLoading = true;

        //obtención de datos
        await GetCurrentWeather(_lastLocation);
        await GetAstronomy(_lastLocation);
        await GetWeatherAlerts(_lastLocation);
        await GetForecast(_lastLocation);
        await GetWeeklyForecast(_lastLocation);

        IsLoading = false;

    }

    /// <summary>
    /// Obtiene el clima actual de la ubicación proporcionada.
    /// </summary>
    private async Task GetCurrentWeather(Location location)
    {
        try
        {
            CurrentWeather = await ApiService.Instance.GetCurrentLocationWeather(location.Latitude, location.Longitude);
            //Guardo la configuracion en las preferencias del dispositivo
            Microsoft.Maui.Storage.Preferences.Default.Set("IsDay", CurrentWeather.current.is_day == 1);

            string? epaIcon = new EpaIndexIconConverter().Convert(CurrentWeather.current.air_quality.usepaindex, typeof(HomeViewModel), null, CultureInfo.CurrentCulture)?.ToString();
            string? defraIcon = new DefraIconConverter().Convert(CurrentWeather.current.air_quality.gbdefraindex, typeof(HomeViewModel), null, CultureInfo.CurrentCulture)?.ToString();

            EpaImageSource = (SkiaSharp.Extended.UI.Controls.SKLottieImageSource)SkiaSharp.Extended.UI.Controls.SKLottieImageSource.FromFile(epaIcon ?? $"{App.NotAvailableIcon}.json");
            DefraImageSource = (SkiaSharp.Extended.UI.Controls.SKLottieImageSource)SkiaSharp.Extended.UI.Controls.SKLottieImageSource.FromFile(defraIcon ?? $"{App.NotAvailableIcon}.json");
        }
        catch (Exception ex)
        {
            await App.Log(ex);
        }
    }

    /// <summary>
    /// Obtiene la información astronómica de la ubicación proporcionada.
    /// </summary>
    private async Task GetAstronomy(Location location)
    {
        try
        {
            DateTime astronomyDate = DateTime.Now.Date;
            if (CurrentWeather.location?.localtime != null)
            {
                astronomyDate = CurrentWeather.location.localtime;
            }

            CurrentAstronomy = await ApiService.Instance.GetLocationAstronomy(location.Latitude, location.Longitude, astronomyDate);

            string? moonPhaseIcon = new MoonPhaseIconConverter().Convert(CurrentAstronomy.astronomy.astro.moon_phase, typeof(HomeViewModel), null, CultureInfo.CurrentCulture)?.ToString();

            MoonImageSource = (SkiaSharp.Extended.UI.Controls.SKLottieImageSource)SkiaSharp.Extended.UI.Controls.SKLottieImageSource.FromFile(moonPhaseIcon ?? $"{App.NotAvailableIcon}.json");

        }
        catch (Exception ex)
        {
            await App.Log(ex);
        }
    }

    /// <summary>
    /// Obtiene las alertas meteorológicas de la ubicación proporcionada.
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    private async Task GetWeatherAlerts(Location location)
    {
        try
        {
            LocationAlerts = await ApiService.Instance.GetWeatherAlerts(location.Latitude, location.Longitude);
        }
        catch (Exception ex)
        {
            await App.Log(ex);
        }
    }

    /// <summary>
    /// Obtiene el pronostico del clima por hora .
    /// </summary>
    private async Task GetForecast(Location location)
    {
        try
        {
            var hourlyForecast = await ApiService.Instance.GetWeatherForecast(location.Latitude, location.Longitude, 1);
            if (hourlyForecast.forecast.forecastday.Count > 0)
            {
                var todayForecast = hourlyForecast.forecast.forecastday[0];
                todayForecast.hour = todayForecast.hour.Where(x => x.time.Hour >= CurrentWeather.location.localtime.Hour).ToList();
            }

            CurrentForecast = hourlyForecast;
        }
        catch (Exception ex)
        {
            await App.Log(ex);
        }
    }

    /// <summary>
    /// Obtiene el pronostico del clima de los días seleccionados.
    /// </summary>
    private async Task GetWeeklyForecast(Location location)
    {
        try
        {
            WeeklyForecast = await ApiService.Instance.GetWeatherForecast(location.Latitude, location.Longitude, ForecastDays);
        }
        catch (Exception ex)
        {
            await App.Log(ex);
        }
    }

    private void GoToSettings()
    {
        //Shell.Current.GoToAsync("SettingsPage");
        Shell.Current.GoToAsync("//SettingsPage");
    }

    private async void Search()
    {
        var page = new SearchPage();
        var viewModel = new SearchViewModel();

        _usingSearchLocation = true;
        //suscripcion de evento para recibir el elemento seleccionado
        viewModel.OnLocationSelected += ViewModel_OnLocationSelected;

        if (App.BottomSheetNavigationService?.NavigationStack().Count > 0)
        {//limpio el stack de navegación antes de mostrar la nueva pantalla
            await App.BottomSheetNavigationService.ClearBottomSheetStackAsync();
        }
        await App.BottomSheetNavigationService!.NavigateToAsync(page, viewModel);
    }

    private async void ViewModel_OnLocationSelected(Location location)
    {
        IsLoading = true;
        _lastLocation = location;

        await LoadData();

        _usingSearchLocation = false;
        IsLoading = false;
    }

    private void StartTimer()
    {
        if (timer != null)
        {//restart timer
            timer.Stop();
        }

        timer = Application.Current?.Dispatcher.CreateTimer();
        if (timer == null)
        {
            return;
        }
        timer.Interval = TimeSpan.FromMinutes(5);
        timer.Tick += (s, e) => Task.Run(async () => await LoadData());
        timer.Start();
    }

}
