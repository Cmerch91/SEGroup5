using Microsoft.Maui.Controls;

namespace SEGroup5.Views;

public partial class RolesPage : ContentPage
{
    public RolesPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var service = new SQLConnection();
        var roles = await service.GetAllFromRoles();
        Roles.ItemsSource = roles;
    }

    private async void OnNavigateBack(object sender, EventArgs e)
    {
    await Navigation.PushAsync(new Admin());
    }

}