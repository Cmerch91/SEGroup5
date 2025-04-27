using Microsoft.Maui.Controls;

namespace SEGroup5.Views;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var service = new SQLConnection();
    }

}