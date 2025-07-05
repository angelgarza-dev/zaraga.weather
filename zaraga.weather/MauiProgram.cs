using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Plugin.Maui.BottomSheet.Hosting;
using SkiaSharp.Views.Maui.Controls.Hosting;
using zaraga.weather.Pages.Home;
using zaraga.weather.Pages.Search;
using zaraga.weather.Pages.Settings;

namespace zaraga.weather;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseSkiaSharp()
            .UseBottomSheet()
            .AddBottomPages()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static MauiAppBuilder AddBottomPages(this MauiAppBuilder builder)
    {
        builder.Services.AddBottomSheet<SearchPage>(nameof(SearchPage));

        return builder;
    }
}