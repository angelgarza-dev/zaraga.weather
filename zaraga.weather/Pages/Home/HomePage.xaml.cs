using Microsoft.Maui.Controls;
using zaraga.weather.Layouts;

namespace zaraga.weather.Pages.Home;

public partial class HomePage : LoadingContentPage
{
    HomeViewModel? _viewModel;

    public HomePage()
    {
        InitializeComponent();
        _viewModel = BindingContext as HomeViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel?.GetGurrentWeatherCommand.Execute(null);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _viewModel?.OnDisapearingCommand.Execute(null);
    }

}