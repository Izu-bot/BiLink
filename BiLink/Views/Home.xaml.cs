using CommunityToolkit.Maui.Views;

namespace BiLink.Views;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
	}

    private void AddLink_Clicked(object sender, EventArgs e)
    {
		var modalPage = new ModalPage();

		this.ShowPopup(modalPage);
    }
}