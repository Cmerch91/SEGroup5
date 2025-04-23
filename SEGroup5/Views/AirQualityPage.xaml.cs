using SEGroup5.ViewModels;

namespace SEGroup5.Views
{
    public partial class AirQualityPage : ContentPage
    {
        public AirQualityPage()
        {
            InitializeComponent();
            BindingContext = new AirQualityViewModel(); 
        }
    }
}