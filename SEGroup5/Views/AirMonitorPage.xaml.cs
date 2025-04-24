using SEGroup5.Services;

namespace SEGroup5.Views;

public partial class AirMonitorPage : ContentPage
{
    public AirMonitorPage()
    {
        InitializeComponent();
        BindingContext = SensorData.AirSensor;
    }
}
