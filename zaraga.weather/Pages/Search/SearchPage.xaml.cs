using Plugin.Maui.BottomSheet;

namespace zaraga.weather.Pages.Search;

public partial class SearchPage : BottomSheet
{
    private SearchViewModel? _viewModel;

    public SearchPage()
    {
        InitializeComponent();
        _viewModel = BindingContext as SearchViewModel;
    }
}