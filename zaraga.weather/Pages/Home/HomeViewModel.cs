using Microsoft.Maui.Controls;
using System;
using System.Diagnostics;
using zaraga.weather.Models;
using zaraga.weather.Services;

namespace zaraga.weather.Pages.Home;

internal class HomeViewModel : SharedViewModel
{
    private string _currentCity = "";
    public string CurrentCity { get => _currentCity; set { _currentCity = value; OnPropertyChanged(); } }


    internal Command GetGurrentWeatherCommand => new Command(GetCurrentWeather);


    internal HomeViewModel()
    {
        CurrentCity = "Cargando...";
    }

    private async void GetCurrentWeather()
    {
        IsLoading = true;
        await GetAppPermissions();
        try
        {
            var location = await GetDeviceLocation();
            if (location != null)
            {
                var resp = await ApiService.Instance.GetRequest<ErrorResponse>($"current.json?key={App.WeatherApikey}&q={location.Latitude},{location.Longitude}&aqi=no", new ErrorResponse());
                CurrentCity = "Mexico";
                Debug.WriteLine(resp.message);
                IsLoading = false;
                await Shell.Current.DisplayAlert("Exito", "Ubicacion obtenida", "OK");
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
            await Shell.Current.DisplayAlert("Error", ex.Message, "ok");
        }
    }
}
