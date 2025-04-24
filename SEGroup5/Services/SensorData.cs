using SEGroup5.Models;

namespace SEGroup5.Services;

public static class SensorData
{
    public static Sensor AirSensor { get; set; } = new Sensor
    {
        Name = "Air Sensor",
        Status = "Online",
        Quantity = "Sulphur dioxide",
        Unit = "ug/m3",
        Frequency = "Hourly",
        SafeLevel = 200,

        Quantity2 = "Nitrogen Dioxide",
        Unit2 = "ug/m3",
        Frequency2 = "Hourly",
        SafeLevel2 = 266, 

        Quantity3 = "Particulate matter <= 2.5 microns in diameter",
        Unit3 = "ug/m3",
        Frequency3 = "Hourly",
        SafeLevel3 = 35, 

        Quantity4 = "Particulate matter <= 10 microns in diameter",
        Unit4 = "ug/m3",
        Frequency4 = "Hourly",
        SafeLevel4 = 50, 



    };

    public static Sensor WaterSensor { get; set; } = new Sensor
    {
        Name = "Water Sensor",
        Quantity = "Nitrite",
        Unit = "mg/l",
        Frequency = "Hourly",
        SafeLevel = 3, 
        Status = "Online"
    };

        public static Sensor WeatherSensor { get; set; } = new Sensor
    {
        Name = "Weather Sensor",
        Quantity = "Air Temperature",
        Unit = "C",
        Frequency = "Hourly", 
        Status = "Online"
    };
}
