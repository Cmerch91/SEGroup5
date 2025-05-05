namespace SEGroup5.Models

// <summary>
// Sensor.cs
// This file contains the Sensor, SensorGroup, and SensorReading classes, which represent the structure of sensor data in the application.
// </summary>
{
    public class SensorReading
    // Represents a single sensor reading with its properties
    // Each reading has a quantity, unit, frequency, and safe level
    {
        public string Quantity { get; set; } = "";
        public string Unit { get; set; } = "";
        public string Frequency { get; set; } = "";
        public double? SafeLevel { get; set; }
    }

    public class SensorGroup

    // Represents a group of sensors with its properties
    // Each group has a name, status, and a list of sensor readings
    // The status indicates whether the sensor is online or offline
    {
        public string Name { get; set; } = "";
        public string Status { get; set; } = "";
        public List<SensorReading> Readings { get; set; } = new();
    }

    public class Sensor
    // Represents the main sensor data structure
    // It contains three groups of sensors: Air, Water, and Weather
    {
        public SensorGroup Air { get; set; } = new();
        public SensorGroup Water { get; set; } = new();
        public SensorGroup Weather { get; set; } = new();
    }
}
