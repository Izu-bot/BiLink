using BiLink.Models.Service;
using BiLink.ViewModels;

namespace BiLink.Views;

public partial class MainPage : ContentPage
{
	private readonly MainPageViewModel _viewModel;

    public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = _viewModel = vm;
    }

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		
		await _viewModel.LoadLinksAsync();

		await _viewModel.LoadCategoriasAsync();
	}
}