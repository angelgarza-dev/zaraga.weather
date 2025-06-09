using AndroidX.Lifecycle;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;
using zaraga.weather.Layouts;
using zaraga.weather.Pages.Home;

namespace zaraga.weather.Pages.Settings;

public partial class SettingsPage : LoadingContentPage
{
    private SettingsViewModel? _settingsViewModel;
    public SettingsPage()
    {
        InitializeComponent();
        _settingsViewModel = BindingContext as SettingsViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        int savedValue;
        try
        {
            savedValue = Preferences.Default.Get("SelectedIconStyle", 0);
        }
        catch (Exception)
        {
            Preferences.Default.Clear("SelectedIconStyle");
            savedValue = 0;
        }
        
        switch (savedValue)
        {
            case 0:
            default:
                btnAnimated.IsChecked = true;
                break;
            case 1:
                btnSolid.IsChecked = true;
                break;
            case 2:
                btnLine.IsChecked = true;
                break;

        }
    }
}