using System;

namespace SEGroup5.Models;

public class WeatherReading
{
    public string Date { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;

    public double? Temperature { get; set; }
    public double? RelativeHumidity { get; set; }
    public double? WindSpeed { get; set; }
    public double? WindDirection { get; set; }
}
