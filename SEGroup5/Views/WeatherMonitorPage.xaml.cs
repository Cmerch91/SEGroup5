using SEGroup5.Services;

namespace SEGroup5.Views;

public partial class WeatherMonitorPage : ContentPage
{
    public WeatherMonitorPage()
    {
        InitializeComponent();
        BindingContext = SensorData.Sensors.Weather;
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
