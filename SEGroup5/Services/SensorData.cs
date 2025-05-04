using SEGroup5.Models;

namespace SEGroup5.Services;

public static class SensorData
{
    public static Sensor AirSensor { get; set; } = new Sensor
    {
        AirName = "Air Sensor",
        AirStatus = "Online",

        AirQuantity = "Sulphur dioxide",
        AirUnit = "ug/m3",
        AirFrequency = "Hourly",
        AirSafeLevel = 200,

        AirQuantity2 = "Nitrogen Dioxide",
        AirUnit2 = "ug/m3",
        AirFrequency2 = "Hourly",
        AirSafeLevel2 = 266,

        AirQuantity3 = "Particulate matter <= 2.5 microns in diameter",
        AirUnit3 = "ug/m3",
        AirFrequency3 = "Hourly",
        AirSafeLevel3 = 35,

        AirQuantity4 = "Particulate matter <= 10 microns in diameter",
        AirUnit4 = "ug/m3",
        AirFrequency4 = "Hourly",
        AirSafeLevel4 = 50,
    };

    public static Sensor WaterSensor { get; set; } = new Sensor
    {
        WaterName = "Water Sensor",
        WaterStatus = "Online",

        WaterQuantity = "Nitrite",
        WaterUnit = "mg/l",
        WaterFrequency = "Hourly",
        WaterSafeLevel = 3,

        WaterQuantity2 = "Nitrate",
        WaterUnit2 = "mg/l",
        WaterFrequency2 = "Hourly",
        WaterSafeLevel2 = 50,

        WaterQuantity3 = "Phosphate",
        WaterUnit3 = "mg/l",
        WaterFrequency3 = "Hourly",
        WaterSafeLevel3 = 0.1,

        WaterQuantity4 = "Escherichia coli",
        WaterUnit4 = "cfu/100ml",
        WaterFrequency4 = "Daily",
        WaterSafeLevel4 = 500,

        WaterQuantity5 = "Intestinal enterococci",
        WaterUnit5 = "cfu/100ml",
        WaterFrequency5 = "Hourly",
        WaterSafeLevel5 = 185,
    };

    public static Sensor WeatherSensor { get; set; } = new Sensor
    {
        WeatherName = "Weather Sensor",
        WeatherStatus = "Online",

        WeatherQuantity = "Air Temperature",
        WeatherUnit = "°C",
        WeatherFrequency = "Hourly",

        WeatherQuantity2 = "Humidity",
        WeatherUnit2 = "%",
        WeatherFrequency2 = "Hourly",

        WeatherQuantity3 = "Wind Speed",
        WeatherUnit3 = "m/s",
        WeatherFrequency3 = "Hourly",

        WeatherQuantity4 = "Wind Direction",
        WeatherUnit4 = "degree",
        WeatherFrequency4 = "Hourly",
    };
}
