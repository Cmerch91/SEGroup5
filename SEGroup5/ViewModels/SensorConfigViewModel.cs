using System;

namespace SEGroup5.ViewModels;

public class SensorConfigViewModel
{
    public string Quantity { get; set; }

    public string Frequency { get; set; }
    public double? SafeLevel { get; set; }

    public List<string> FrequencyOptions { get; } = new() { "Hourly", "Daily" };

    public Action ApplyChanges { get; set; } = () => { };

    public string? NewFrequency => Frequency;
    public double? NewSafeLevel => SafeLevel;
}
