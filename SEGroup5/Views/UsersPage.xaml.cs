namespace SEGroup5.Views;

public partial class UsersPage : ContentPage
{
    public UsersPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var service = new SQLConnection();
        var users = await service.GetAllFromUsers();
        Users.ItemsSource = users;
    }

    private async void OnNavigateBack(object sender, EventArgs e)
    {
    await Navigation.PushAsync(new Admin());
    }

}
