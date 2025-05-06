using SEGroup5.ViewModels;

namespace SEGroup5.Views
{
    public partial class RolesPage : ContentPage
    {
        // Constructor for RolesPage
        // Initializes the page and sets the BindingContext to an instance of WaterQualityViewModel
        // This allows the page to bind to properties and commands defined in the ViewModel
        public RolesPage()
        {
            InitializeComponent();
            BindingContext = new RolesPageViewModel();
        }

        private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		rolesCollection.SelectedItem = null;
	}

        private async void OnNavigateBack(object sender, EventArgs e)
        {
        await Navigation.PushAsync(new Admin());
        }
    }
}