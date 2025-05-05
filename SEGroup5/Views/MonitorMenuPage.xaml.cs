using SEGroup5.Views;

namespace SEGroup5.Views;

public partial class MonitorMenuPage : ContentPage
{
    public MonitorMenuPage()
    {
        InitializeComponent();
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
    await Navigation.PopAsync();
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
    private async void OnNavigateToAirConfigPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ConfigAirSensorPage());
    }
    private async void OnNavigateToWaterConfigPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ConfigWaterSensorPage());
    }
    private async void OnNavigateToWeatherConfigPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ConfigWeatherSensorPage());
    }
}
