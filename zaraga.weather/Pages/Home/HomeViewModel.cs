using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Threading.Tasks;
using zaraga.weather.Models;
using zaraga.weather.Services;

namespace zaraga.weather.Pages.Home;

public class HomeViewModel : SharedViewModel
{
    private string _completeJson = "";
    private WeatherCurrentLocation _currentWeather = new();
    private WeatherForecastAstro _currentAstronomy = new();
    private WeatherAlerts _locationAlerts = new();
    private WeatherForecast _currentForecast = new();
    private WeatherForecast _weeklyForecast = new();
    private int _forecastDays = 2;
    private bool _forecastLoading = false;


    public string CompleteJson { get => _completeJson; set { _completeJson = value; OnPropertyChanged(); } }
    public WeatherCurrentLocation CurrentWeather { get => _currentWeather; set { _currentWeather = value; OnPropertyChanged(); } }
    public WeatherForecastAstro CurrentAstronomy { get => _currentAstronomy; set { _currentAstronomy = value; OnPropertyChanged(); } }
    public WeatherAlerts LocationAlerts { get => _locationAlerts; set { _locationAlerts = value; OnPropertyChanged(); } }
    public WeatherForecast CurrentForecast { get => _currentForecast; set { _currentForecast = value; OnPropertyChanged(); } }
    public WeatherForecast WeeklyForecast { get => _weeklyForecast; set { _weeklyForecast = value; OnPropertyChanged(); } }
    public int ForecastDays { get => _forecastDays; set { _forecastDays = value; OnPropertyChanged(); } }
    public bool ForecastLoading { get => _forecastLoading; set { _forecastLoading = value; OnPropertyChanged(); } }


    public Command LoadDataCommand => new Command(LoadData);
    public Command OnDisapearingCommand => new Command(OnDisapearing);
    public Command OnForecastDaysChangeCommand => new Command(OnForecastDaysChange);


    public HomeViewModel()
    {
    }

    private void OnDisapearing()
    {

    }

    private async void OnForecastDaysChange()
    {
        ForecastLoading = true;
        var location = await GetDeviceLocation();
        if (location == null)
        {
            IsLoading = false;
            await Shell.Current.DisplayAlert("Error", "No se pudo obtener la ubicación", "OK");
            return;
        }

        await GetWeeklyForecast(location);
        ForecastLoading = false;
    }

    private async void LoadData()
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
            IsLoading = false;
            await Shell.Current.DisplayAlert("Error", "No se pudo obtener la ubicación", "OK");
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
                astronomyDate = CurrentWeather.location.localtime.Value;
            }

            CurrentAstronomy = await ApiService.Instance.GetLocationAstronomy(location.Latitude, location.Longitude, astronomyDate);
            //CompleteJson = Newtonsoft.Json.JsonConvert.SerializeObject(CurrentAstronomy, Newtonsoft.Json.Formatting.Indented);

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
            CurrentForecast = await ApiService.Instance.GetWeatherForecast(location.Latitude, location.Longitude, 1);
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
}
