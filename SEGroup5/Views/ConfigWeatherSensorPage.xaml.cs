using SEGroup5.Services;
using SEGroup5.ViewModels;

namespace SEGroup5.Views;

public partial class ConfigWeatherSensorPage : ContentPage
{
    public ConfigWeatherSensorPage()
    {
    InitializeComponent();
    BindingContext = new ConfigWeatherSensorViewModel(SensorData.Sensors.Weather);
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
