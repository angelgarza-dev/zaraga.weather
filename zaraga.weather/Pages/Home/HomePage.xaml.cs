using epj.Expander.Maui;
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
        _viewModel?.LoadDataCommand.Execute(null);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _viewModel?.OnDisapearingCommand.Execute(null);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        _viewModel?.OnForecastDaysChangeCommand.Execute(null);
    }

    private void Expander_HeaderTapped(object sender, epj.Expander.Maui.ExpandedEventArgs e)
    {
        if (sender is Expander)
        {
            if ((sender as Expander)!.IsExpanded)
            {
                scrol.ScrollToAsync(expHeader, ScrollToPosition.Start, true);
            }
        }
    }
}