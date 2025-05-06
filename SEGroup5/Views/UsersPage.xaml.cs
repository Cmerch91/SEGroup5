using System.Collections.ObjectModel;
using SEGroup5.Models;
using SEGroup5.ViewModels;

namespace SEGroup5.Views
{
    public partial class UsersPage : ContentPage
    {
        // Constructor for UsersPage
        // Initializes the page and sets the BindingContext to an instance of WaterQualityViewModel
        // This allows the page to bind to properties and commands defined in the ViewModel
        public UsersPage()
        {
            InitializeComponent();
            BindingContext = new UsersPageViewModel();
        }

        private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	    {
		usersCollection.SelectedItem = null;
	    }

        private async void OnNavigateBack(object sender, EventArgs e)
        {
        await Navigation.PushAsync(new Admin());
        }
    }
}