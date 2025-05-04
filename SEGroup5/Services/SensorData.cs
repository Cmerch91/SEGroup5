using SEGroup5.Models;

namespace SEGroup5.Services;

/// <summary>
/// SensorData.cs  
/// /// This file contains the SensorData class, which is responsible for managing the sensor data and providing it to the views.
/// /// </summary>

public static class SensorData
{
    public static Sensor Sensors { get; set; } = new Sensor
    {
        Air = new SensorGroup
        {
            Name = "Air Sensor",
            Status = "Online",
            Readings = new List<SensorReading>
            // List of sensor readings for air quality
            // Each reading has a quantity, unit, frequency, and safe level 
            // Safe level is the maximum acceptable level for that reading
            // The readings are based on the World Health Organization (WHO) guidelines for air quality
            {
                new() { Quantity = "Sulphur dioxide", Unit = "ug/m3", Frequency = "Hourly", SafeLevel = 200 },
                new() { Quantity = "Nitrogen Dioxide", Unit = "ug/m3", Frequency = "Hourly", SafeLevel = 266 },
                new() { Quantity = "Particulate matter <= 2.5 microns in diameter", Unit = "ug/m3", Frequency = "Hourly", SafeLevel = 35 },
                new() { Quantity = "Particulate matter <= 10 microns in diameter", Unit = "ug/m3", Frequency = "Hourly", SafeLevel = 50 }
            }
        },

        Water = new SensorGroup
        {
            Name = "Water Sensor",
            Status = "Online",
            Readings = new List<SensorReading>
            // List of sensor readings for water quality
            // Each reading has a quantity, unit, frequency, and safe level
            // Safe level is the maximum acceptable level for that reading
            {
                new() { Quantity = "Nitrite", Unit = "mg/l", Frequency = "Hourly", SafeLevel = 3 },
                new() { Quantity = "Nitrate", Unit = "mg/l", Frequency = "Hourly", SafeLevel = 50 },
                new() { Quantity = "Phosphate", Unit = "mg/l", Frequency = "Hourly", SafeLevel = 0.1 },
                new() { Quantity = "Escherichia coli", Unit = "cfu/100ml", Frequency = "Daily", SafeLevel = 500 },
                new() { Quantity = "Intestinal enterococci", Unit = "cfu/100ml", Frequency = "Hourly", SafeLevel = 185 }
            }
        },

        Weather = new SensorGroup
        {
            Name = "Weather Sensor",
            Status = "Online",
            Readings = new List<SensorReading>
            // List of sensor readings for weather
            // Each reading has a quantity, unit, frequency, and safe level
            // Safe level is the maximum acceptable level for that reading
            {
                new() { Quantity = "Air Temperature", Unit = "°C", Frequency = "Hourly" },
                new() { Quantity = "Humidity", Unit = "%", Frequency = "Hourly" },
                new() { Quantity = "Wind Speed", Unit = "m/s", Frequency = "Hourly" },
                new() { Quantity = "Wind Direction", Unit = "degree", Frequency = "Hourly" }
            }
        }
    };
}
