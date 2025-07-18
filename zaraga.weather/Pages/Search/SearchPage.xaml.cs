using Microsoft.Maui;
using Plugin.Maui.BottomSheet;
using System.Threading.Tasks;

namespace zaraga.weather.Pages.Search;

public partial class SearchPage : BottomSheet
{
    private SearchViewModel? _viewModel;

    public SearchPage()
    {
        InitializeComponent();
        _viewModel = BindingContext as SearchViewModel;
        this.Opened += SearchPage_Opened;
    }

    private async void SearchPage_Opened(object? sender, System.EventArgs e)
    {
        if (!txtSearch.IsSoftInputShowing())
            await txtSearch.ShowSoftInputAsync(System.Threading.CancellationToken.None);
    }

    private async void txtSearch_Unfocused(object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        if (txtSearch.IsSoftInputShowing())
            await txtSearch.HideSoftInputAsync(System.Threading.CancellationToken.None);
    }

    private async void SwipeGestureRecognizer_Swiped(object sender, Microsoft.Maui.Controls.SwipedEventArgs e)
    {
        if (txtSearch.IsSoftInputShowing())
            await txtSearch.HideSoftInputAsync(System.Threading.CancellationToken.None);
    }

    private async void TapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (txtSearch.IsSoftInputShowing())
            await txtSearch.HideSoftInputAsync(System.Threading.CancellationToken.None);
    }

    private void ModalBottomSheet_Closed(object sender, System.EventArgs e)
    {

    }

    private void txtSearch_TextChanged(object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {

    }
}