using System;

namespace SEGroup5.Models;

public class WaterReading
{
    public string Date { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;

    public double? Nitrate { get; set; }
    public double? Nitrite { get; set; }
    public double? Phosphate { get; set; }
    public double? EColi { get; set; }
}