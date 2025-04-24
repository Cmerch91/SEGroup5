using SEGroup5.Views;


namespace SEGroup5;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}

	private async void OnNavigateToDataMenu(object sender, EventArgs e)
{
    await Navigation.PushAsync(new DataMenuPage());
}
	private async void OnNavigateToMonitorPage(object sender, EventArgs e)
{
    await Navigation.PushAsync(new MonitorMenuPage());
}
}