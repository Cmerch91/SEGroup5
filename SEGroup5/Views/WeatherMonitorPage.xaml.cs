using SEGroup5.Services;


namespace SEGroup5.Views;

public partial class WeatherMonitorPage : ContentPage
{
	public WeatherMonitorPage()
	{
		InitializeComponent();
		BindingContext = SensorData.WeatherSensor;
	}
}