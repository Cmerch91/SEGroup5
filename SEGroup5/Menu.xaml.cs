using SEGroup5.Views;


namespace SEGroup5;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}

	private async void OnNavigateToReadingsPage(object sender, EventArgs e)
{
    await Navigation.PushAsync(new Readings());
}

private async void OnNavigateToLoginPage(object sender, EventArgs e)
{
    await Navigation.PushAsync(new Login());
}
}