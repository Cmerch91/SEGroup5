using SEGroup5.Views;

namespace SEGroup5;

public partial class Admin : ContentPage
{
	public Admin()
	{
		InitializeComponent();
	}

	private async void OnNavigateToRolesPage(object sender, EventArgs e)
{
    await Navigation.PushAsync(new RolePage());
}

private async void OnNavigateToUsersPage(object sender, EventArgs e)
{
    await Navigation.PushAsync(new UsersPage());
}

private async void OnNavigateBack(object sender, EventArgs e)
{
    await Navigation.PushAsync(new Menu());
}

}