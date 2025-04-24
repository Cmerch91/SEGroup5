using SEGroup5.Models;
using SEGroup5.Services;
using System.Collections.Generic;

namespace SEGroup5.ViewModels;

public class SensorViewModel
{
    public Sensor AirSensor => SensorData.AirSensor;
    public Sensor WaterSensor => SensorData.WaterSensor;
    public Sensor WeatherSensor => SensorData.WeatherSensor;

    public List<string> StatusOptions { get; } = new() { "Online", "Offline" };
}
