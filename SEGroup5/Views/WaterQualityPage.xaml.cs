using SEGroup5.ViewModels;

namespace SEGroup5.Views
{
    public partial class WaterQualityPage : ContentPage
    {
        // Constructor for WaterQualityPage
        // Initializes the page and sets the BindingContext to an instance of WaterQualityViewModel
        // This allows the page to bind to properties and commands defined in the ViewModel
        public WaterQualityPage()
        {
            InitializeComponent();
            BindingContext = new WaterQualityViewModel();
        }
    }
}