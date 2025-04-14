using Microsoft.Maui.Controls;

namespace SEGroup5.Views;

public partial class Readings : ContentPage
{
    public Readings()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var service = new SqlService();
        var noonReadings = await service.GetNoonReadingsAsync();
        ReadingsView.ItemsSource = noonReadings;
    }
}