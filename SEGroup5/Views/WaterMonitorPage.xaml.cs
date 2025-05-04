using SEGroup5.Services;

namespace SEGroup5.Views;

public partial class WaterMonitorPage : ContentPage
{
    public WaterMonitorPage()
    {
        InitializeComponent();
        BindingContext = SensorData.Sensors.Water;
    }
}
