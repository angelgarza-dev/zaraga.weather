using Android.Print;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System.Collections.Generic;
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

    public int PageSize { get => _pageSize; set { _pageSize = value; OnPropertyChanged(); } }


    private ObservableCollection<IconModel> _iconsCollection = new ObservableCollection<IconModel>();
    public ObservableCollection<IconModel> IconsCollection { get => _iconsCollection; set { _iconsCollection = value; OnPropertyChanged(); } }


    public Command LoadImagesCommand => new Command(LoadImages);
    public Command AddListPageCommand => new Command(AddListPage);


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
            "extreme_day_drizzle",
            "extreme_day_fog",
            "extreme_day_hail",
            "extreme_day_haze",
            "extreme_day_rain",
            "extreme_day_sleet",
            "extreme_day_smoke",
            "extreme_day_snow",
            "extreme_drizzle",
            "extreme_fog",
            "extreme_hail",
            "extreme_haze",
            "extreme_night",
            "extreme_night_drizzle",
            "extreme_night_fog",
            "extreme_night_hail",
            "extreme_night_haze",
            "extreme_night_rain",
            "extreme_night_sleet",
            "extreme_night_smoke",
            "extreme_night_snow",
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
            "overcast_day_drizzle",
            "overcast_day_fog",
            "overcast_day_hail",
            "overcast_day_haze",
            "overcast_day_rain",
            "overcast_day_sleet",
            "overcast_day_smoke",
            "overcast_day_snow",
            "overcast_drizzle",
            "overcast_fog",
            "overcast_hail",
            "overcast_haze",
            "overcast_night",
            "overcast_night_drizzle",
            "overcast_night_fog",
            "overcast_night_hail",
            "overcast_night_haze",
            "overcast_night_rain",
            "overcast_night_sleet",
            "overcast_night_smoke",
            "overcast_night_snow",
            "overcast_rain",
            "overcast_sleet",
            "overcast_smoke",
            "overcast_snow",
            "partly_cloudy_day",
            "partly_cloudy_day_drizzle",
            "partly_cloudy_day_fog",
            "partly_cloudy_day_hail",
            "partly_cloudy_day_haze",
            "partly_cloudy_day_rain",
            "partly_cloudy_day_sleet",
            "partly_cloudy_day_smoke",
            "partly_cloudy_day_snow",
            "partly_cloudy_night",
            "partly_cloudy_night_drizzle",
            "partly_cloudy_night_fog",
            "partly_cloudy_night_hail",
            "partly_cloudy_night_haze",
            "partly_cloudy_night_rain",
            "partly_cloudy_night_sleet",
            "partly_cloudy_night_smoke",
            "partly_cloudy_night_snow",
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
            "thunderstorms_day_extreme",
            "thunderstorms_day_extreme_rain",
            "thunderstorms_day_extreme_snow",
            "thunderstorms_day_overcast",
            "thunderstorms_day_overcast_rain",
            "thunderstorms_day_overcast_snow",
            "thunderstorms_day_rain",
            "thunderstorms_day_snow",
            "thunderstorms_extreme",
            "thunderstorms_extreme_rain",
            "thunderstorms_extreme_snow",
            "thunderstorms_night",
            "thunderstorms_night_extreme",
            "thunderstorms_night_extreme_rain",
            "thunderstorms_night_extreme_snow",
            "thunderstorms_night_overcast",
            "thunderstorms_night_overcast_rain",
            "thunderstorms_night_overcast_snow",
            "thunderstorms_night_rain",
            "thunderstorms_night_snow",
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

    //carga la lista de imagenes disponibles para los iconos
    private void LoadImages()
    {
        IsLoading = true;
        IconsCollection.Clear();
        _currentPage = 0;
        string sourcePrefix = GetImageSourcePrefix();

        string[] initialPage = completeIcon.Skip(_currentPage).Take(_pageSize).ToArray();
        foreach (var icon in initialPage)
        {
            IconsCollection.Add(new IconModel(icon, sourcePrefix + icon));
        }

        _currentPage++;
        IsLoading = false;
    }

    private void AddListPage()
    {
        if (_addingPage) { return; }
        _addingPage = true;
        IsLoading = true;

        string sourcePrefix = GetImageSourcePrefix();

        Task.Run(async () =>
        {
            string[] initialPage = completeIcon.Skip(_currentPage * _pageSize).Take(_pageSize).ToArray();
            foreach (var icon in initialPage)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    IconsCollection.Add(new IconModel(icon, sourcePrefix + icon));
                });
                await Task.Delay(100);
            }
        });

        _currentPage++;
        IsLoading = false;
        _addingPage = false;
    }

    private string GetImageSourcePrefix()
    {
        string sourcePrefix = "static_fill_";
        int iconStyle = Preferences.Default.Get("SelectedIconStyle", 0);
        switch (iconStyle)
        {
            case 0:
            default:
                sourcePrefix = "Raw/Dynamic/Fill/dynamic_fill_";
                break;
            case 1:
                sourcePrefix = "static_fill_";
                break;
            case 2:
                sourcePrefix = "static_line_";
                break;


        }

        return sourcePrefix;
    }

}


public class IconModel : PropertyChangedViewModel
{
    public string Name { get; set; }
    public string Source { get; set; }

    public IconModel(string name, string source)
    {
        Name = name;
        Source = source;
    }

}