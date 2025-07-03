using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Linq;
using System.Threading.Tasks;
using zaraga.weather.Models;
using zaraga.weather.Services;

namespace zaraga.weather.Pages.Home;

public class HomeViewModel : SharedViewModel
{
    private WeatherCurrentLocation _currentWeather = new();
    private WeatherForecastAstro _currentAstronomy = new();
    private WeatherAlerts _locationAlerts = new();
    private WeatherForecast _currentForecast = new();
    private WeatherForecast _weeklyForecast = new();
    private int _forecastDays = 3;
    private bool _forecastLoading = false;


    public WeatherCurrentLocation CurrentWeather { get => _currentWeather; set { _currentWeather = value; OnPropertyChanged(); } }
    public WeatherForecastAstro CurrentAstronomy { get => _currentAstronomy; set { _currentAstronomy = value; OnPropertyChanged(); } }
    public WeatherAlerts LocationAlerts { get => _locationAlerts; set { _locationAlerts = value; OnPropertyChanged(); } }
    public WeatherForecast CurrentForecast { get => _currentForecast; set { _currentForecast = value; OnPropertyChanged(); } }
    public WeatherForecast WeeklyForecast { get => _weeklyForecast; set { _weeklyForecast = value; OnPropertyChanged(); } }
    public int ForecastDays { get => _forecastDays; set { _forecastDays = value; OnPropertyChanged(); } }
    public bool ForecastLoading { get => _forecastLoading; set { _forecastLoading = value; OnPropertyChanged(); } }


    public Command LoadDataCommand => new Command(async () => await LoadData());
    public Command OnDisapearingCommand => new Command(OnDisapearing);
    public Command OnForecastDaysChangeCommand => new Command(OnForecastDaysChange);
    public Command GoToSettingsCommand => new Command(GoToSettings);


    public HomeViewModel()
    {
    }

    private void OnDisapearing()
    {

    }

    private async void OnForecastDaysChange()
    {
        //excepcion para no onteber datos duplicados
        if (IsLoading) return;

        ForecastLoading = true;
        var location = await GetDeviceLocation();
        if (location == null)
        {
            IsLoading = false;
            return;
        }

        await GetWeeklyForecast(location);
        ForecastLoading = false;
    }

    private async Task LoadData()
    {
        IsLoading = true;
        if (CurrentWeather.location != null)
        {
            CurrentWeather.location.name = "Cargando...";
        }

        //permisos y ubicación actual
        await GetAppPermissions();
        var location = await GetDeviceLocation();
        if (location == null)
        {
            return;
        }

        //obtención de datos
        await Task.WhenAll(
            GetCurrentWeather(location),
            GetAstronomy(location),
            GetWeatherAlerts(location),
            GetForecast(location),
            GetWeeklyForecast(location)
        );

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
        }
        catch (Exception ex)
        {
            App.Log(ex);
            await Shell.Current.DisplayAlert("Error", ex.Message, "ok");
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
        }
        catch (Exception ex)
        {
            App.Log(ex);
            await Shell.Current.DisplayAlert("Error", ex.Message, "ok");
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
            App.Log(ex);
            await Shell.Current.DisplayAlert("Error", ex.Message, "ok");
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
            var todayForecast = hourlyForecast.forecast.forecastday[0];
            todayForecast.hour = todayForecast.hour.Where(x => x.time.Hour >= CurrentWeather.location.localtime.Hour).ToList();

            CurrentForecast = hourlyForecast;
        }
        catch (Exception ex)
        {
            App.Log(ex);
            await Shell.Current.DisplayAlert("Error", ex.Message, "ok");
        }
    }

    /// <summary>
    /// Obtiene el pronostico del clima de los dias seleccionados.
    /// </summary>
    private async Task GetWeeklyForecast(Location location)
    {
        try
        {
            WeeklyForecast = await ApiService.Instance.GetWeatherForecast(location.Latitude, location.Longitude, ForecastDays);
        }
        catch (Exception ex)
        {
            App.Log(ex);
            await Shell.Current.DisplayAlert("Error", ex.Message, "ok");
        }
    }

    private void GoToSettings()
    {
        Shell.Current.GoToAsync("//SettingsPage");
    }
}
