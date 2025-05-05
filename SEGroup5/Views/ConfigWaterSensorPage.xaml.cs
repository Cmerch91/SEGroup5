using SEGroup5.ViewModels;
using SEGroup5.Services;

namespace SEGroup5.Views;

public partial class ConfigWaterSensorPage : ContentPage
{
    public ConfigWaterSensorPage()
    {
    InitializeComponent();
    BindingContext = new ConfigWaterSensorViewModel(SensorData.Sensors.Water);
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
