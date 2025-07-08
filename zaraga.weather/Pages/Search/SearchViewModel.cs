using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zaraga.weather.Models;
using zaraga.weather.Services;

namespace zaraga.weather.Pages.Search
{
    public class SearchViewModel : SharedViewModel
    {
        private ObservableCollection<WeatherLocation> _locationList = new();
        private string _SearchText = "";

        public ObservableCollection<WeatherLocation> LocationList { get => _locationList; set { _locationList = value; OnPropertyChanged(); } }
        public string SearchText { get => _SearchText; set { _SearchText = value; OnPropertyChanged(); } }


        public Command SearchCommand => new Command(Search);
        public Command CloseModalCommand => new Command(CloseModal);
        public Command SelectLocationCommand => new Command<object>(SelectLocation);


        //evento al seleccionar un elemento de la busqueda
        public delegate void LocationSelectedEventHandler(Location location);
        public event LocationSelectedEventHandler? OnLocationSelected;

        private void TriggerItemSelected(Location item)
        {
            LocationSelectedEventHandler? handler = OnLocationSelected;
            if (handler != null)
            {
                handler(item);
            }
        }

        public SearchViewModel()
        {

        }

        private async void Search()
        {
            try
            {
                IsLoading = true;
                var locations = await ApiService.Instance.SearchLocation(SearchText);
                IsLoading = false;

                LocationList = new ObservableCollection<WeatherLocation>(locations);
            }
            catch (Exception ex)
            {
                await App.Log(ex);
            }
        }

        private async void CloseModal()
        {
            var location = await GetDeviceLocation();
            if (location == null)
            {
                await App.Log(new Exception("No se pudo obtener la ubicación actual del dispositivo."));
                return;
            }
            TriggerItemSelected(location);

            await App.BottomSheetNavigationService!.ClearBottomSheetStackAsync();
        }

        private async void SelectLocation(object item)
        {
            var loc = new Location();
            loc.Latitude = (item as WeatherLocation)!.lat;
            loc.Longitude = (item as WeatherLocation)!.lon;

            TriggerItemSelected(loc);

            await App.BottomSheetNavigationService!.ClearBottomSheetStackAsync();
        }
    }
}
