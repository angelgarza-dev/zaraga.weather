using AndroidX.Lifecycle;
using epj.Expander.Maui;
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

        //Expando el primer elemento por defecto 
        var firstChildren = AccordionLayout.Children[0];
        if (firstChildren is Expander expander)
        {
            expander.IsExpanded = true;
        }

        Expander_HeaderTapped(firstChildren, new epj.Expander.Maui.ExpandedEventArgs { Expanded = true });
    }

    private void Expander_HeaderTapped(object sender, epj.Expander.Maui.ExpandedEventArgs e)
    {
        if (sender is not Expander expander)
        {
            return;
        }

        foreach (var child in AccordionLayout.Children)
        {
            if (child is not Expander other)
            {
                continue;
            }

            if (other != expander)
            {
                other.IsExpanded = false;
            }
        }
    }
}