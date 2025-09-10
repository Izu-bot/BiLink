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

	protected override void OnAppearing()
	{
		base.OnAppearing();
		if (_viewModel.Links.Count == 0)
			_viewModel.LoadLinksCommand.Execute(null);
    }
}