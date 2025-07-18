using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using zaraga.weather.Converters;
using zaraga.weather.Models;

namespace zaraga.weather.Views;

public partial class IconView : ContentView, INotifyPropertyChanged
{
    private static string[] dayNightIcons =
    {
        "clear",
        "fog",
        "partly_cloudy",
        "partly_cloudy_rain",
        "partly_cloudy_snow",
        "partly_cloudy_sleet",
        "drizzle",
        "overcast_drizzle"
    };
    private string _iconsource = "";
    private string _sourcePrefix;
    private int _iconType;
    private bool _animatedVisible;
    private bool _statickVisible;
    private SkiaSharp.Extended.UI.Controls.SKLottieImageSource _imageSource = (SkiaSharp.Extended.UI.Controls.SKLottieImageSource)SkiaSharp.Extended.UI.Controls.SKLottieImageSource.FromFile(App.NotAvailableIcon);


    public string IconSource { get => _iconsource; set { _iconsource = value; NotifyPropertyChanged(); } }
    public int IconType { get => _iconType; set { _iconType = value; NotifyPropertyChanged(); } }
    public bool AnimatedVisible { get => _animatedVisible; set { _animatedVisible = value; NotifyPropertyChanged(); } }
    public bool StatickVisible { get => _statickVisible; set { _statickVisible = value; NotifyPropertyChanged(); } }
    public SkiaSharp.Extended.UI.Controls.SKLottieImageSource ImageSource { get => _imageSource; set { _imageSource = value; NotifyPropertyChanged(); } }

    private double _parentHeight;
    private double _parentWidth;

    public double ParentHeight
    {
        get { return _parentHeight; }
        set { _parentHeight = value; NotifyPropertyChanged(); }
    }

    public double ParentWidth
    {
        get { return _parentWidth; }
        set { _parentWidth = value; NotifyPropertyChanged(); }
    }



    public static BindableProperty IconBindableProperty = BindableProperty.Create("IconBindable", typeof(int), typeof(IconView), 0, propertyChanged: OnIconPropertyChanged);
    public static BindableProperty IconHeightProperty = BindableProperty.Create("IconHeight", typeof(double), typeof(IconView), propertyChanged: OnIconHeightPropertyChanged);
    public static BindableProperty IconWidthProperty = BindableProperty.Create("IconWidth", typeof(double), typeof(IconView), propertyChanged: OnIconWidthPropertyChanged);

    public int IconBindable { get => (int)GetValue(IconBindableProperty); set => SetValue(IconBindableProperty, value); }
    public double IconHeight { get => (double)GetValue(IconHeightProperty); set => SetValue(IconHeightProperty, value); }
    public double IconWidth { get => (double)GetValue(IconWidthProperty); set => SetValue(IconWidthProperty, value); }



    public IconView()
    {
        InitializeComponent();
        BindingContext = this;
        _iconsource = "";
        _sourcePrefix = "";
    }


    /// <summary>
    /// Obtiene la direccion del icono segun la configuración
    /// </summary>
    private string GetImageSourcePrefix()
    {
        string sourcePrefix = "static_fill_";
        int iconStyle = Preferences.Default.Get("SelectedIconStyle", 0);
        switch (iconStyle)
        {
            case 0:
            default:
                //sourcePrefix = "Dynamic/Fill/dynamic_fill_";
                sourcePrefix = "dynamic_fill_";
                break;
            case 1:
                sourcePrefix = "static_fill_";
                break;
            case 2:
                sourcePrefix = "static_line_";
                break;


        }

        return sourcePrefix;
    }


    private static void OnIconPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is IconView iconView && newValue is int neeWeatherCode)
        {
            string icon_name = new IconCodeConverter().Convert(neeWeatherCode, typeof(IconView), null, CultureInfo.CurrentCulture)?.ToString() ?? App.NotAvailableIcon;

            string icon_sufix = "";
            //Obtiene el tipo de icono seleccionado segun la configuración
            iconView.IconType = Preferences.Default.Get("SelectedIconStyle", 0);
            iconView._sourcePrefix = iconView.GetImageSourcePrefix();


            if (dayNightIcons.Contains(icon_name))
            {
                bool isDay = Preferences.Default.Get("IsDay", true);
                icon_sufix = isDay ? "_day" : "_night";
            }

            if (icon_name == App.NotAvailableIcon)
            {
                iconView.AnimatedVisible = true;
                iconView.StatickVisible = false;
                iconView.ImageSource = (SkiaSharp.Extended.UI.Controls.SKLottieImageSource)SkiaSharp.Extended.UI.Controls.SKLottieImageSource.FromFile("na.json");
            }
            else if (iconView.IconType > 0)
            {
                iconView.AnimatedVisible = false;
                iconView.StatickVisible = true;

                string iconPath = iconView._sourcePrefix + icon_name + icon_sufix;
                iconView.IconSource = iconPath;
                iconView.ImageSource = (SkiaSharp.Extended.UI.Controls.SKLottieImageSource)SkiaSharp.Extended.UI.Controls.SKLottieImageSource.FromFile(App.NotAvailableIcon);
            }
            else
            {
                iconView.AnimatedVisible = true;
                iconView.StatickVisible = false;
                string iconPath = iconView._sourcePrefix + icon_name + icon_sufix + ".json";
                iconView.IconSource = "";
                iconView.ImageSource = (SkiaSharp.Extended.UI.Controls.SKLottieImageSource)SkiaSharp.Extended.UI.Controls.SKLottieImageSource.FromFile(iconPath);
                //ImageSource = SkiaSharp.Extended.UI.Controls.SKLottieImageSource.FromFile("Dynamic/Fill/dynamic_fill_clear_night.json") as SkiaSharp.Extended.UI.Controls.SKLottieImageSource;
            }

        }
    }


    private static void OnIconHeightPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is IconView iconView && newValue is double newHeight)
        {
            iconView.ParentHeight = newHeight;
        }
    }


    private static void OnIconWidthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is IconView iconView && newValue is double newWidth)
        {
            iconView.ParentWidth = newWidth;
        }
    }


    #region notify property changed
    public new event PropertyChangedEventHandler? PropertyChanged;

    protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

}