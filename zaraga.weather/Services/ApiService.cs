using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using zaraga.weather.Models;

namespace zaraga.weather.Services;

internal class ApiService
{
    //Singleton instance
    private static ApiService? _instance;
    internal static ApiService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ApiService();
            }
            return _instance;
        }
    }

    private readonly bool _useRetries;
    private readonly int _maxRetries;
    private readonly zaraga.api.Client _apiClient;
    private int _retryCount;


    internal ApiService(bool useRetries = false, int maxRetries = 1)
    {
        _useRetries = useRetries;
        _maxRetries = maxRetries;
        _retryCount = 0;
        _apiClient = new zaraga.api.Client(BuildMetadata.BaseWeatherapiUrl);
    }

    /// <summary>
    /// Llamada HTTP GET de un endopint
    /// </summary>
    private async Task<T> GetRequest<T>(string url, T? handleResp) where T : new()
    {
        App.Log("Start call");
        App.Log($"GET : {url}");
        try
        {
            T? resp = await _apiClient.Get<T>(url, handleResp);
            App.Log($"Response received");
            App.Log(JsonConvert.SerializeObject(resp));
            if (resp != null)
            {
                return resp;
            }
            else
            {
                return handleResp != null ? handleResp : new T();
            }
        }
        catch (Exception ex)
        {
            App.Log(ex);
            if (_useRetries)
            {
                if (_retryCount >= _maxRetries)
                {
                    _retryCount = 0;
                    App.Log("Max retries reached");
                    throw;
                }
                else
                {
                    _retryCount++;
                    App.Log($"Run retry {_retryCount} of {_maxRetries}");
                    return await GetRequest<T>(url, handleResp);
                }
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Obtiene la zona horaria de una ubicacion por coordenadas
    /// </summary>
    public async Task<WeatherTimeZone> GetLocationTimeZone(double latitude, double longitude)
    {
        var resp = await GetRequest($"timezone.json?key={App.WeatherApikey}&q={latitude},{longitude}&lang=es", new WeatherTimeZone());
        return resp;
    }

    /// <summary>
    /// Obtiene las horas de amanecer y atardecer de una ubicacion por coordenadas
    /// </summary>
    public async Task<WeatherForecastAstro> GetLocationAstronomy(double latitude, double longitude)
    {
        var resp = await GetRequest($"astronomy.json?key={App.WeatherApikey}&q={latitude},{longitude}&lang=es", new WeatherForecastAstro());
        return resp;
    }

    /// <summary>
    /// Obtiene el clima de la ubicacion actual por coordenadas
    /// </summary>
    public async Task<WeatherCurrentLocation> GetCurrentLocationWeather(double latitude, double longitude)
    {
        var resp = await GetRequest($"current.json?key={App.WeatherApikey}&q={latitude},{longitude}&lang=es", new WeatherCurrentLocation());
        return resp;
    }

}
