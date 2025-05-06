using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using SEGroup5.Models;

namespace SEGroup5.ViewModels;

public class UsersPageViewModel : INotifyPropertyChanged
{

    public ObservableCollection<object> Users { get; } = new();

    public Command LoadUsersCommand { get; }
    //public Command AddUserCommand { get; }
    public ICommand AddUserCommand { get; }
    public ICommand SelectUserCommand { get; }


    public UsersPageViewModel()
    {
        LoadUsersCommand = new Command(async () => await GetAllUsers());
        //AddUserCommand = new Command(async () => await NewUserAsync());
        AddUserCommand = new AsyncRelayCommand(NewUserAsync);
        SelectUserCommand = new AsyncRelayCommand<UserPageViewModel>(SelectUserAsync);
    }

    private async Task NewUserAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.UserPage));
    }

    private async Task SelectUserAsync(UserPageViewModel user)
    {
        if (user != null)
            await Shell.Current.GoToAsync($"Views.UserPage");
    }

    private async Task GetAllUsers()
    {
        var sql = new SQLConnection();

        var results = await sql.GetAllFromUsers();

        Console.WriteLine($"Returned {results.Count} readings from Users");

        Users.Clear();
        foreach (var r in results)
        {
            Users.Add(r);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}