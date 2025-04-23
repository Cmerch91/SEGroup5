using SEGroup5.ViewModels;

namespace SEGroup5.Views
{
    public partial class WaterQualityPage : ContentPage
    {
        public WaterQualityPage()
        {
            InitializeComponent();
            BindingContext = new WaterQualityViewModel();
        }
    }
}