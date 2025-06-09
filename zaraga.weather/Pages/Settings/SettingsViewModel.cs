using Java.Security;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace zaraga.weather.Pages.Settings;

public class SettingsViewModel : SharedViewModel
{
    private int _selectedIconStyle;


    public int SelectedIConStyle { get => _selectedIconStyle; set { _selectedIconStyle = value; OnIconStyleChange(value); } }


    public Command LoadSettingsCommand => new Command(LoadSettings);

    public SettingsViewModel()
    {
        LoadSettings();
    }

    private void LoadSettings()
    {
        try
        {

            _selectedIconStyle = Preferences.Default.Get("SelectedIconStyle", 0);
        }
        catch (Exception)
        {
            Preferences.Default.Clear("SelectedIconStyle");
            _selectedIconStyle = 0;
        }
    }




    private void OnIconStyleChange(int selectedIconStyle)
    {
        OnPropertyChanged(nameof(SelectedIConStyle));
        Preferences.Default.Set("SelectedIconStyle", selectedIconStyle);
    }


}
