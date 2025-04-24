namespace SEGroup5.Views;

public partial class DataMenuPage : ContentPage
{
	public DataMenuPage()
	{
		InitializeComponent();
	}
	private async void OnNavigateToAirQualityPage(object sender, EventArgs e)
	{
    await Navigation.PushAsync(new AirQualityPage());
	}
		private async void OnNavigateToWaterQualityPage(object sender, EventArgs e)
	{
    await Navigation.PushAsync(new WaterQualityPage());
	}
	private async void OnNavigateToWeatherPage(object sender, EventArgs e)
	{
    await Navigation.PushAsync(new WeatherPage());
	}
}