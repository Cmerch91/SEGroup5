using SEGroup5.ViewModels;

namespace SEGroup5.Views
{
    public partial class RolePage : ContentPage
    {
        // Constructor for RolesPage
        // Initializes the page and sets the BindingContext to an instance of WaterQualityViewModel
        // This allows the page to bind to properties and commands defined in the ViewModel
        public RolePage()
        {
            InitializeComponent();
            BindingContext = new RolePageViewModel();
        }

        private async void OnNavigateBack(object sender, EventArgs e)
        {
        await Navigation.PushAsync(new RolesPage());
        }
    }
}