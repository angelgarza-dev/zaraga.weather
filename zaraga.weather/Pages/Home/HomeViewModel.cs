using Microsoft.Maui.Controls;
using System;
using zaraga.weather.Models;
using zaraga.weather.Services;

namespace zaraga.weather.Pages.Home;

public class HomeViewModel : SharedViewModel
{
    private string _completeJson = "";
    private WeatherCurrentLocation _currentWeather = new();
    private string _currentCondition = "";


    public string CompleteJson { get => _completeJson; set { _completeJson = value; OnPropertyChanged(); } }
    public WeatherCurrentLocation CurrentWeather { get => _currentWeather; set { _currentWeather = value; OnPropertyChanged(); } }
    public string CurrentCondition { get => _currentCondition; set { _currentCondition = value; OnPropertyChanged(); } }



    public Command GetGurrentWeatherCommand => new Command(GetCurrentWeather);
    public Command OnDisapearingCommand => new Command(OnDisapearing);


    public HomeViewModel()
    {

    }

    private void OnDisapearing()
    {
        CurrentCondition = "";
    }

    private async void GetCurrentWeather()
    {
        IsLoading = true;
        if (CurrentWeather.location != null)
        {
            CurrentWeather.location.name = "Cargando...";
        }

        await GetAppPermissions();

        try
        {
            var location = await GetDeviceLocation();
            if (location != null)
            {
                CurrentWeather = await ApiService.Instance.GetCurrentLocationWeather(location.Latitude, location.Longitude);
                string icon = CurrentWeather.current?.condition?.code.ToString() ?? "0";
                CurrentCondition = icon;
                IsLoading = false;
            }
            else
            {
                //IsLoading = false;
                await Shell.Current.DisplayAlert("Error", "No se pudo obtener la ubicacion", "OK");
            }
        }
        catch (Exception ex)
        {
            IsLoading = false;
            App.Log(ex);
            await Shell.Current.DisplayAlert("Error", ex.Message, "ok");
        }
    }

}
