using SEGroup5.Models;
using SEGroup5.Services;
using System.Collections.Generic;

// <summary>
// SensorViewModel.cs
// This file contains the SensorViewModel class, which is responsible for managing the sensor data and providing it to the views.
// </summary>

namespace SEGroup5.ViewModels
{
    public class SensorViewModel
    {
        public Sensor Sensors => SensorData.Sensors;

        public SensorGroup AirSensor => Sensors.Air;
        public SensorGroup WaterSensor => Sensors.Water;
        public SensorGroup WeatherSensor => Sensors.Weather;

        public List<string> StatusOptions { get; } = new() { "Online", "Offline" };
    }
}
