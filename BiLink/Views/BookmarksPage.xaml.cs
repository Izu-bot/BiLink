using BiLink.ViewModels;
using System.Threading.Tasks;

namespace BiLink.Views;

public partial class BookmarksPage : ContentPage
{
	private readonly BookmarksPageViewModel _viewModel;

	public BookmarksPage(BookmarksPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = _viewModel = vm;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await _viewModel.ExecuteLoadCategoriaCommand();
	}
}