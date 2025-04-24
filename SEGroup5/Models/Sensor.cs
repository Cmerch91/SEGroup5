namespace SEGroup5.Models;

public class Sensor
{
    public string Name { get; set; } = "";
    public string Quantity { get; set; } = "";
    public string Unit { get; set; } = "";
    public string Frequency { get; set; } = "";
    public int SafeLevel { get; set; } = 50;
    public string Status { get; set; } = "";

    public string Quantity2 { get; set; } = "";
    public string Unit2 { get; set; } = "";
    public string Frequency2 { get; set; } = "";
    public int SafeLevel2 { get; set; }

    public string Quantity3 { get; set; } = "";
    public string Unit3 { get; set; } = "";
    public string Frequency3 { get; set; } = "";
    public int SafeLevel3 { get; set; }

    public string Quantity4 { get; set; } = "";
    public string Unit4 { get; set; } = "";
    public string Frequency4 { get; set; } = "";
    public int SafeLevel4 { get; set; }
}