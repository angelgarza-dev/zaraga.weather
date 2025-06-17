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


    public string CompleteJson { get => _completeJson; set { _completeJson = value; OnPropertyChanged(); } }
    public WeatherCurrentLocation CurrentWeather { get => _currentWeather; set { _currentWeather = value; OnPropertyChanged(); } }
    public WeatherForecastAstro CurrentAstronomy { get => _currentAstronomy; set { _currentAstronomy = value; OnPropertyChanged(); } }


    public Command LoadDataCommand => new Command(LoadData);
    public Command OnDisapearingCommand => new Command(OnDisapearing);


    public HomeViewModel()
    {

    }

    private void OnDisapearing()
    {

    }

    private async void LoadData()
    {
        IsLoading = true;
        if (CurrentWeather.location != null)
        {
            CurrentWeather.location.name = "Cargando...";
        }

        //permisos y ubicacion actual
        await GetAppPermissions();
        var location = await GetDeviceLocation();
        if (location == null)
        {
            IsLoading = false;
            await Shell.Current.DisplayAlert("Error", "No se pudo obtener la ubicacion", "OK");
            return;
        }

        //obtencion de datos
        await Task.WhenAll(
            GetCurrentWeather(location),
            GetAstronomy(location)
        );

        IsLoading = false;
    }

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
            CompleteJson = Newtonsoft.Json.JsonConvert.SerializeObject(CurrentAstronomy, Newtonsoft.Json.Formatting.Indented);

        }
        catch (Exception ex)
        {
            App.Log(ex);
            await Shell.Current.DisplayAlert("Error", ex.Message, "ok");
        }
    }

}
