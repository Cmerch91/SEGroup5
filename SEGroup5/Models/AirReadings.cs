using System;

namespace SEGroup5.Models;

public class AirReading
{
    public string Date { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;

    public double? NO2 { get; set; }
    public double? SO2 { get; set; }
    public double? PM25 { get; set; }
    public double? PM10 { get; set; }
}
