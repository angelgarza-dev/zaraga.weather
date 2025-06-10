using Microsoft.Maui.Controls;
using System.Reflection;
using zaraga.weather.Layouts;

namespace zaraga.weather.Pages.Icons;

public partial class IconsPage : ContentPage
{
    private IconViewModel? _viewModel;
    public IconsPage()
    {
        InitializeComponent();
        _viewModel = BindingContext as IconViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (txtSearch.Text == string.Empty)
        {
            _viewModel?.LoadImagesCommand.Execute(null);
        }
        else
        {
            txtSearch.Text = string.Empty;
        }
    }

    private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        _viewModel?.FilterIconsCommand.Execute(e.NewTextValue);
    }
}