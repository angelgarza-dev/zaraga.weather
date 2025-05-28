using Microsoft.Maui.Controls;
using Newtonsoft.Json;
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
                var resp = await ApiService.Instance.GetCurrentLocationWeather(location.Latitude, location.Longitude);
                CurrentCity = resp.location?.name ?? "";
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
            await Shell.Current.DisplayAlert("Error", ex.Message, "ok");
        }
    }
}
