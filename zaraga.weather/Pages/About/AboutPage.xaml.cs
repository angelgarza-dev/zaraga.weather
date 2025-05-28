using Microsoft.Maui.Controls;
using zaraga.weather.Layouts;

namespace zaraga.weather.Pages.About;

public partial class AboutPage : LoadingContentPage
{
    public AboutPage()
    {
        InitializeComponent();
        BindingContext = new AboutViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}