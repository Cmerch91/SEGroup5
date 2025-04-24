namespace SEGroup5.Views;

public partial class MonitorMenuPage : ContentPage
{
	public MonitorMenuPage()
	{
		InitializeComponent();
	}

		private async void OnNavigateToAirMonitorPage(object sender, EventArgs e)
	{
    await Navigation.PushAsync(new AirMonitorPage());
	}
}