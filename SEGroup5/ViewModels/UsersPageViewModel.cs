using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SEGroup5.ViewModels;

public class UsersPageViewModel : INotifyPropertyChanged
{

    public ObservableCollection<object> Users { get; set; } = new();

    public Command LoadUsersCommand { get; }


    public UsersPageViewModel()
    {
            LoadUsersCommand = new Command(async () => await GetAllUsers());
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