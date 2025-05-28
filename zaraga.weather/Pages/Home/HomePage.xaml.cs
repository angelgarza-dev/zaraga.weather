using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using zaraga.weather.Models;
using zaraga.weather.Services;
using zaraga.weather.Layouts;

namespace zaraga.weather.Pages.Home;

public partial class HomePage : LoadingContentPage
{
    HomeViewModel? _viewModel;

    public HomePage()
    {
        InitializeComponent();
        //BindingContext = _viewModel = new HomeViewModel();
        _viewModel = BindingContext as HomeViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel?.GetGurrentWeatherCommand.Execute(null);
    }

}