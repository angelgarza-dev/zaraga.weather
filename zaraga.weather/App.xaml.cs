using epj.Expander.Maui;
using Microsoft.Maui.Controls;
using Plugin.Maui.BottomSheet.Navigation;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using zaraga.weather.Attributes;

namespace zaraga.weather;

public partial class App : Application
{
    internal static string NotAvailableIcon => "not_available";
    internal static string WeatherApikey => Assembly.GetExecutingAssembly()?.GetCustomAttribute<WeatherApiKeyAttribute>()?.WeatherKey.ToString() ?? "";
    internal static IBottomSheetNavigationService? BottomSheetNavigationService;


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

    public App(IBottomSheetNavigationService _bottomSheetNavigationService)
    {
        InitializeComponent();
        BottomSheetNavigationService = _bottomSheetNavigationService;

        Console.Init(filePath: BuildMetadata.LogPath, daysToRecord: 3);
        Expander.EnableAnimations();

        MainPage = new AppShell();
    }

    internal static void Log(string message)
    {
        Console.Write(message);
#if DEBUG
        Debug.WriteLine("{0} - {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), message);
#endif
    }

    internal static async Task Log(Exception exception)
    {
        Console.Write(exception);
#if DEBUG
        Debug.WriteLine("Exception message:");
        Debug.WriteLine("{0} - {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), exception?.Message);
        Debug.WriteLine("InnerException message:");
        Debug.WriteLine("{0} - {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), exception?.InnerException?.Message);
#endif
        await Shell.Current.DisplayAlert("Error", exception?.Message ?? "Ops por favor vuelva a intentar.", "OK");
    }
}