using Microsoft.Maui.Controls;
using System;
using System.Diagnostics;
using System.Reflection;
using zaraga.weather.Attributes;

namespace zaraga.weather;

public partial class App : Application
{
    internal static string NotAvailableIcon => "not_available";
    internal static string WeatherApikey => Assembly.GetExecutingAssembly()?.GetCustomAttribute<WeatherApiKeyAttribute>()?.WeatherKey.ToString() ?? "";


    //Log Manager 
    private static zaraga.logger.Manager? _console;
    private static zaraga.logger.Manager Console
    {
        get
        {
            if (_console == null)
            {
                _console = zaraga.logger.Manager.Instance;
            }
            return _console;
        }
    }

    public App()
    {
        InitializeComponent();

        Console.Init(filePath: BuildMetadata.LogPath, daysToRecord: 3);

        MainPage = new AppShell();
    }

    internal static void Log(string message)
    {
        Console.Write(message);
#if DEBUG
        Debug.WriteLine("{0} - {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), message);
#endif
    }

    internal static void Log(Exception exception)
    {
        Console.Write(exception);
#if DEBUG
        Debug.WriteLine("Exception message:");
        Debug.WriteLine("{0} - {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), exception?.Message);
        Debug.WriteLine("InnerException message:");
        Debug.WriteLine("{0} - {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), exception?.InnerException?.Message);
#endif
    }
}