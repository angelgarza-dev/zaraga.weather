using System.Threading.Tasks;
using zaraga.devicefeatures;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;
using zaraga.weather.Services;
using System;

namespace zaraga.weather;

public class SharedViewModel : PropertyChangedViewModel
{
    private bool _isLoading = false;
    private WeatherIndicatorIcons _indicators;


    public bool IsLoading { get => _isLoading; set { _isLoading = value; OnPropertyChanged(); } }
    public WeatherIndicatorIcons WeatherIndicators { get => _indicators; set { _indicators = value; OnPropertyChanged(); } }


    private readonly DeviceSensors _devicefeatures;


    public SharedViewModel()
    {
        _devicefeatures = new DeviceSensors();
        _indicators = new WeatherIndicatorIcons();
    }

    /// <summary>
    /// Obtiene todos los permisos necesarios
    /// </summary>
    internal async Task GetAppPermissions()
    {
        App.Log("Getting location in use permission");
        var locationPermission = await _devicefeatures.CheckAndRequestPermissionAsync(new Permissions.LocationWhenInUse());
        App.Log($"Location permission status: {locationPermission}");
    }

    /// <summary>
    /// Obtiene la ubicacion actual del dispositivo si se cuenta con el permiso.
    /// </summary>
    internal async Task<Location?> GetDeviceLocation()
    {
        App.Log("Checking location in use permission");
        var locationPermission = await _devicefeatures.CheckPermissionStatus(new Permissions.LocationWhenInUse());
        App.Log($"Location permission status: {locationPermission}");
        if (locationPermission == PermissionStatus.Granted)
        {
            App.Log("Getting Current location");
            var deviceLocation = await _devicefeatures.GetCurrentLocation();
            App.Log($"Current location: Latitude:{deviceLocation?.Latitude}, Longitude:{deviceLocation?.Longitude}");
            return deviceLocation;
        }
        else
        {
            return null;
        }
    }
}

public class WeatherIndicatorIcons
{
    public int Overcast { get; } = 1009;
    public int Barometer { get; } = 5001;
    public int Celsius { get; } = 5002;
    public int Compass { get; } = 5003;
    public int Fahrenheit { get; } = 5004;
    public int Horizon { get; } = 5005;
    public int Humidity { get; } = 5006;
    public int RaindropMeasure { get; } = 5007;
    public int StarryNight { get; } = 5008;
    public int Pollen { get; } = 5009;
    public int UVIndex { get; } = 5010;
    public int Wind { get; } = 5011;
    public int Windsock { get; } = 5012;
    //Astronómicos
    public int Moonrise { get; } = 5101;
    public int Moonset { get; } = 5102;
    public int Sunrise { get; } = 5103;
    public int Sunset { get; } = 5104;
    //Fases de la luna
    public int MoonFirstQuarter { get; } = 5201;
    public int MoonFull { get; } = 5202;
    public int MoonLastQuarter { get; } = 5203;
    public int MoonNew { get; } = 5204;
    public int MoonWaningCrescent { get; } = 5205;
    public int MoonWaningGibbous { get; } = 5206;
    public int MoonWaxingCrescent { get; } = 5207;
    public int MoonWaxingGibbous { get; } = 5208;
    //Indicadores
    public int CodeGreen { get; } = 5301;
    public int CodeOrange { get; } = 5302;
    public int CodeRed { get; } = 5303;
    public int CodeYellow { get; } = 5304;
}
