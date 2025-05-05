using SEGroup5.ViewModels;
using SEGroup5.Services;

namespace SEGroup5.Views;

public partial class ConfigAirSensorPage : ContentPage
{
    public ConfigAirSensorPage()
    {
    InitializeComponent();
    BindingContext = new ConfigAirSensorViewModel(SensorData.Sensors.Air);
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}