using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaraga.weather.Pages.About;

public class AboutViewModel : SharedViewModel
{

    public Command OpenBrowserCommand => new Command(OpenBrowser);
    public Command OpenBassDevCommand => new Command(OpenBassDev);


    /// <summary>
    /// Abre el navegador web con la pagina web de WeatherAPI
    /// </summary>
    private async void OpenBrowser()
    {
        await Browser.Default.OpenAsync(new Uri("https://www.weatherapi.com"), new BrowserLaunchOptions
        {
            LaunchMode = BrowserLaunchMode.SystemPreferred,
            TitleMode = BrowserTitleMode.Show,
            PreferredToolbarColor = Color.FromArgb("#2B0B98"),
            PreferredControlColor = Colors.SandyBrown
        });
    }

    private async void OpenBassDev()
    {
        await Browser.Default.OpenAsync(new Uri("https://bas.dev/work/meteocons"), new BrowserLaunchOptions
        {
            LaunchMode = BrowserLaunchMode.SystemPreferred,
            TitleMode = BrowserTitleMode.Show,
            PreferredToolbarColor = Color.FromArgb("#2B0B98"),
            PreferredControlColor = Colors.SandyBrown
        });
    }

}
