using System;

namespace SEGroup5.ViewModels;

public class WeatherViewModel : DataQueryViewModel
{
    // Constructor for WeatherViewModel
    // Initializes the SelectedTable property to "Weather"
    public WeatherViewModel()
    {
        SelectedTable = "Weather";
    }
}