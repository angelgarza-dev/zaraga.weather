using AndroidX.Lifecycle;
using Microsoft.Maui.Controls;
using zaraga.weather.Layouts;
using zaraga.weather.Pages.Home;

namespace zaraga.weather.Pages.Settings;

public partial class SettingsPage : LoadingContentPage
{
    public SettingsPage()
    {
        InitializeComponent();

        BindingContext = new SettingsViewModel();
    }
}