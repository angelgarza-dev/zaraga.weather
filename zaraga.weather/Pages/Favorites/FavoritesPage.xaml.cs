using Microsoft.Maui.Controls;
using zaraga.weather.Layouts;

namespace zaraga.weather.Pages.Favorites;

public partial class FavoritesPage : LoadingContentPage
{
	public FavoritesPage()
	{
		InitializeComponent();
        BindingContext = new FavoritesViewModel();
    }
}