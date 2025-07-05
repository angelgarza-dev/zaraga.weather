using Microsoft.Maui.Controls;
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
        private TaskCompletionSource<WeatherLocation> tcs;
        private ObservableCollection<WeatherLocation> _locationList = new();
        private string _SearchText = "";

        public Task<WeatherLocation> OnSelectedLocation => tcs.Task;
        public ObservableCollection<WeatherLocation> LocationList { get => _locationList; set { _locationList = value; OnPropertyChanged(); } }
        public string SearchText { get => _SearchText; set { _SearchText = value; OnPropertyChanged(); } }


        public Command SearchCommand => new Command(Search);
        public Command CloseModalCommand => new Command(CloseModal);

        public SearchViewModel()
        {
            tcs = new TaskCompletionSource<WeatherLocation>();
        }

        public SearchViewModel(string searchText)
        {
            tcs = new TaskCompletionSource<WeatherLocation>();
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
            tcs.SetResult(null);
            //await App.BottomSheetNavigationService!.ClearBottomSheetStackAsync();
        }

    }
}
