using Mvvmdex.ViewModels;
using Xamarin.Forms;

namespace Mvvmdex.Views
{
	public partial class MvvmdexPage : ContentPage
	{
		public MvvmdexPage()
		{
		    BindingContext = new PokemonSearchViewModel();
			InitializeComponent();
		}
	}
}

