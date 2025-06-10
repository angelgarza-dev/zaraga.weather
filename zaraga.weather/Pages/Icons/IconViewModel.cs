using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace zaraga.weather.Pages.Icons;

public class IconViewModel : SharedViewModel
{
    private string[] completeIcon = new string[] { };
    private int _currentPage = 0;
    private int _pageSize = 15;
    private bool _addingPage = false;
    private bool _filtered = false;

    public int PageSize { get => _pageSize; set { _pageSize = value; OnPropertyChanged(); } }


    private ObservableCollection<IconModel> _iconsCollection = new ObservableCollection<IconModel>();
    public ObservableCollection<IconModel> IconsCollection { get => _iconsCollection; set { _iconsCollection = value; OnPropertyChanged(); } }


    public Command LoadImagesCommand => new Command(LoadImages);
    public Command AddListPageCommand => new Command(AddListPage);
    public Command FilterIconsCommand => new Command<string>(FilterIcons);


    public IconViewModel()
    {
        completeIcon = new string[]
            {
           "alert_avalanche_danger",
            "alert_falling_rocks",
            "barometer",
            "beanie",
            "celsius",
            "clear_day",
            "clear_night",
            "cloudy",
            "cloud_down",
            "cloud_up",
            "code_green",
            "code_orange",
            "code_red",
            "code_yellow",
            "compass",
            "drizzle",
            "dust",
            "dust_day",
            "dust_night",
            "dust_wind",
            "extreme",
            "extreme_day",
            "extreme_drizzle_day",
            "extreme_fog_day",
            "extreme_hail_day",
            "extreme_haze_day",
            "extreme_rain_day",
            "extreme_sleet_day",
            "extreme_smoke_day",
            "extreme_snow_day",

            "extreme_drizzle",
            "extreme_fog",
            "extreme_hail",
            "extreme_haze",
            "extreme_night",
            "extreme_drizzle_night",
            "extreme_fog_night",
            "extreme_hail_night",
            "extreme_haze_night",
            "extreme_rain_night",
            "extreme_sleet_night",
            "extreme_smoke_night",
            "extreme_snow_night",
            "extreme_rain",
            "extreme_sleet",
            "extreme_smoke",
            "extreme_snow",
            "fahrenheit",
            "falling_stars",
            "flag_gale_warning",
            "flag_hurricane_warning",
            "flag_small_craft_advisory",
            "flag_storm_warning",
            "fog",
            "fog_day",
            "fog_night",
            "glove",
            "hail",
            "haze",
            "haze_day",
            "haze_night",
            "horizon",
            "humidity",
            "hurricane",
            "lightning_bolt",
            "mist",
            "moonrise",
            "moonset",
            "moon_first_quarter",
            "moon_full",
            "moon_last_quarter",
            "moon_new",
            "moon_waning_crescent",
            "moon_waning_gibbous",
            "moon_waxing_crescent",
            "moon_waxing_gibbous",
            "not_available",
            "overcast",
            "overcast_day",
            "overcast_drizzle_day",
            "overcast_fog_day",
            "overcast_hail_day",
            "overcast_haze_day",
            "overcast_rain_day",
            "overcast_sleet_day",
            "overcast_smoke_day",
            "overcast_snow_day",
            "overcast_drizzle",
            "overcast_fog",
            "overcast_hail",
            "overcast_haze",
            "overcast_night",
            "overcast_drizzle_night",
            "overcast_fog_night",
            "overcast_hail_night",
            "overcast_haze_night",
            "overcast_rain_night",
            "overcast_sleet_night",
            "overcast_smoke_night",
            "overcast_snow_night",
            "overcast_rain",
            "overcast_sleet",
            "overcast_smoke",
            "overcast_snow",
            "partly_cloudy_day",
            "partly_cloudy_drizzle_day",
            "partly_cloudy_fog_day",
            "partly_cloudy_hail_day",
            "partly_cloudy_haze_day",
            "partly_cloudy_rain_day",
            "partly_cloudy_sleet_day",
            "partly_cloudy_smoke_day",
            "partly_cloudy_snow_day",
            "partly_cloudy_night",
            "partly_cloudy_drizzle_night",
            "partly_cloudy_fog_night",
            "partly_cloudy_hail_night",
            "partly_cloudy_haze_night",
            "partly_cloudy_rain_night",
            "partly_cloudy_sleet_night",
            "partly_cloudy_smoke_night",
            "partly_cloudy_snow_night",
            "pollen",
            "pollen_flower",
            "pollen_grass",
            "pollen_tree",
            "pressure_high",
            "pressure_high_alt",
            "pressure_low",
            "pressure_low_alt",
            "rain",
            "rainbow",
            "rainbow_clear",
            "raindrop",
            "raindrops",
            "raindrop_measure",
            "sleet",
            "smoke",
            "smoke_particles",
            "snow",
            "snowflake",
            "snowman",
            "solar_eclipse",
            "star",
            "starry_night",
            "sunrise",
            "sunset",
            "sun_hot",
            "thermometer",
            "thermometer_celsius",
            "thermometer_colder",
            "thermometer_fahrenheit",
            "thermometer_glass",
            "thermometer_glass_celsius",
            "thermometer_glass_fahrenheit",
            "thermometer_mercury",
            "thermometer_mercury_cold",
            "thermometer_moon",
            "thermometer_raindrop",
            "thermometer_snow",
            "thermometer_sun",
            "thermometer_warmer",
            "thermometer_water",
            "thunderstorms",
            "thunderstorms_day",
            "thunderstorms_extreme_day",
            "thunderstorms_extreme_rain_day",
            "thunderstorms_extreme_snow_day",
            "thunderstorms_overcast_day",
            "thunderstorms_overcast_rain_day",
            "thunderstorms_overcast_snow_day",
            "thunderstorms_rain_day",
            "thunderstorms_snow_day",
            "thunderstorms_extreme",
            "thunderstorms_extreme_rain",
            "thunderstorms_extreme_snow",
            "thunderstorms_night",
            "thunderstorms_extreme_night",
            "thunderstorms_extreme_rain_night",
            "thunderstorms_extreme_snow_night",
            "thunderstorms_overcast_night",
            "thunderstorms_overcast_rain_night",
            "thunderstorms_overcast_snow_night",
            "thunderstorms_rain_night",
            "thunderstorms_snow_night",
            "thunderstorms_overcast",
            "thunderstorms_overcast_rain",
            "thunderstorms_overcast_snow",
            "thunderstorms_rain",
            "thunderstorms_snow",
            "tide_high",
            "tide_low",
            "time_afternoon",
            "time_evening",
            "time_late_afternoon",
            "time_late_evening",
            "time_late_morning",
            "time_late_night",
            "time_morning",
            "time_night",
            "tornado",
            "umbrella",
            "umbrella_wind",
            "umbrella_wind_alt",
            "uv_index",
            "uv_index_1",
            "uv_index_10",
            "uv_index_11",
            "uv_index_2",
            "uv_index_3",
            "uv_index_4",
            "uv_index_5",
            "uv_index_6",
            "uv_index_7",
            "uv_index_8",
            "uv_index_9",
            "wind",
            "windsock",
            "windsock_weak",
            "wind_alert",
            "wind_beaufort_0",
            "wind_beaufort_1",
            "wind_beaufort_10",
            "wind_beaufort_11",
            "wind_beaufort_12",
            "wind_beaufort_2",
            "wind_beaufort_3",
            "wind_beaufort_4",
            "wind_beaufort_5",
            "wind_beaufort_6",
            "wind_beaufort_7",
            "wind_beaufort_8",
            "wind_beaufort_9",
            "wind_offshore",
            "wind_onshore",
            "wind_snow"
        };

    }

    /// <summary>
    /// Carga la lista de imagenes disponibles para los iconos
    /// </summary>
    private void LoadImages()
    {
        IsLoading = true;
        _filtered = false;
        _currentPage = 0;
        IconsCollection.Clear();

        string[] initialPage = completeIcon.Skip(_currentPage).Take(_pageSize).ToArray();
        foreach (var icon in initialPage)
        {
            IconsCollection.Add(new IconModel(icon));
        }

        _currentPage++;
        IsLoading = false;
    }

    /// <summary>
    /// Agrega la sigueinte pagina de iconos a la lista actual
    /// </summary>
    private void AddListPage()
    {
        if (_addingPage || _filtered) { return; }

        _addingPage = true;
        IsLoading = true;

        Task.Run(async () =>
        {
            string[] initialPage = completeIcon.Skip(_currentPage * _pageSize).Take(_pageSize).ToArray();
            foreach (var icon in initialPage)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    IconsCollection.Add(new IconModel(icon));
                });
                await Task.Delay(100);
            }
        });

        _currentPage++;
        IsLoading = false;
        _addingPage = false;
    }

    private void FilterIcons(string? searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            _filtered = false;
            LoadImages();
            return;
        }

        _filtered = true;
        IsLoading = true;
        IconsCollection.Clear();
        
        var filteredIcons = completeIcon.Where(icon => icon.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToArray();
        foreach (var icon in filteredIcons)
        {
            IconsCollection.Add(new IconModel(icon));
            //await Task.Delay(100);
        }
        IsLoading = false;
    }
}

public class IconModel : PropertyChangedViewModel
{
    //private string _name = "";
    public string Name
    {
        get; set;
        //get => _name;
        //set { _name = value; }
    }

    public IconModel(string name)
    {
        Name = name;
    }

}