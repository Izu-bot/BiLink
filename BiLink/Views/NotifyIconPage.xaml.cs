using CommunityToolkit.Mvvm.Input;
using H.NotifyIcon;
using System.Windows.Input;

namespace BiLink.Views;

public partial class NotifyIconPage : ContentPage
{
	private bool IsWindowVisible { get; set; } = true;
    public NotifyIconPage()
    {
        InitializeComponent();
    }

    [RelayCommand]
    public void ShowHideWindow()
    {
        var window = Application.Current?.Windows[0];
        if (window == null) return;

        if(IsWindowVisible)
        {
            window.Hide();
        }
        else
        {
            window.Show();
            window.Activate();
        }

        IsWindowVisible = !IsWindowVisible;
    }

    [RelayCommand]
    public void ExitApplication()
    {
        Application.Current?.Quit();
    }
}