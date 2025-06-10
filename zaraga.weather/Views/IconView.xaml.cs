using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace zaraga.weather.Views;

public partial class IconView : ContentView, INotifyPropertyChanged
{
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



    public static readonly BindableProperty IconBindableProperty = BindableProperty.Create("IconBindable", typeof(string), typeof(IconView), "", propertyChanged: OnIconPropertyChanged);
    public string IconBindable
    {
        get => GetValue(IconBindableProperty).ToString() ?? "";
        set => SetValue(IconBindableProperty, value);
    }


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
                sourcePrefix = "Dynamic/Fill/dynamic_fill_";
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
        if (bindable is IconView iconView && newValue is string newIcon)
        {
            //Obtiene el tipo de icono seleccionado segun la configuración
            iconView.IconType = Preferences.Default.Get("SelectedIconStyle", 0);
            iconView._sourcePrefix = iconView.GetImageSourcePrefix();


            if (iconView.IconType > 0)
            {
                iconView.AnimatedVisible = false;
                iconView.StatickVisible = true;

                string iconPath = iconView._sourcePrefix + newIcon;
                iconView.IconSource = iconPath;
                iconView.ImageSource = (SkiaSharp.Extended.UI.Controls.SKLottieImageSource)SkiaSharp.Extended.UI.Controls.SKLottieImageSource.FromFile(App.NotAvailableIcon);
            }
            else
            {
                iconView.AnimatedVisible = true;
                iconView.StatickVisible = false;
                string iconPath = iconView._sourcePrefix + newIcon + ".json";
                iconView.IconSource = "";
                iconView.ImageSource = (SkiaSharp.Extended.UI.Controls.SKLottieImageSource)SkiaSharp.Extended.UI.Controls.SKLottieImageSource.FromFile(iconPath);
                //ImageSource = SkiaSharp.Extended.UI.Controls.SKLottieImageSource.FromFile("Dynamic/Fill/dynamic_fill_clear_night.json") as SkiaSharp.Extended.UI.Controls.SKLottieImageSource;
            }

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