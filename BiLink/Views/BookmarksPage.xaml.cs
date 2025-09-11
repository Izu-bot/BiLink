using BiLink.ViewModels;

namespace BiLink.Views;

public partial class BookmarksPage : ContentPage
{
	private readonly BookmarksPageViewModel _viewModel;

	public BookmarksPage(BookmarksPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = _viewModel = vm;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		if (_viewModel.Categorias.Count == 0)
			_viewModel.LoadCategoriaCommand.Execute(null);
	}
}