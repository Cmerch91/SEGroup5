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
		private async void OnNavigateToWaterMonitorPage(object sender, EventArgs e)
	{
    await Navigation.PushAsync(new WaterMonitorPage());
	}
		private async void OnNavigateToWeatherMonitorPage(object sender, EventArgs e)
	{
    await Navigation.PushAsync(new WeatherMonitorPage());
	}
}