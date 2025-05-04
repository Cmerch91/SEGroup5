using SEGroup5.ViewModels;

namespace SEGroup5.Views
{
    public partial class AirQualityPage : ContentPage
    {
        // Constructor for AirQualityPage
        // Initializes the page and sets the BindingContext to an instance of AirQualityViewModel
        // This allows the page to bind to properties and commands defined in the ViewModel
        public AirQualityPage()
        {
            InitializeComponent();
            BindingContext = new AirQualityViewModel(); 
        }
    }
}