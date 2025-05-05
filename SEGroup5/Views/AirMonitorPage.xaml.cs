using SEGroup5.Services;
using SEGroup5.Models;

namespace SEGroup5.Views;

public partial class AirMonitorPage : ContentPage
{
    public AirMonitorPage()
    {
        InitializeComponent();
        BindingContext = SensorData.Sensors.Air;
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
