using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SEGroup5.Models;

namespace SEGroup5.ViewModels;

public class RolesPageViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Role> Roles {get; set; } = new();

    public Command LoadRolesCommand { get; }
    public Command AddRoleCommand { get; }
    public Command SelectRoleCommand { get; }

    public RolesPageViewModel()
    {
        LoadRolesCommand = new Command(async () => await GetAllRoles());
        AddRoleCommand = new Command(async () => await NewRoleAsync());
        SelectRoleCommand = new Command(async () => await SelectRoleAsync());
    }

    private async Task NewRoleAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.RolePage)); 
    }

    private async Task SelectRoleAsync(ViewModels.RolePageViewModel role)
    {
        if (role != null){

            await Shell.Current.GoToAsync($"{nameof(Views.NotePage)}?load={role.Identifier}");

        }
            
    }


    private async Task GetAllRoles()
    {
        var sql = new SQLConnection();

        var results = await sql.GetAllFromRoles();

        Console.WriteLine($"Returned {results.Count} readings from Roles");

        Roles.Clear();
        foreach (var r in results)
        {
            Role role = new Role();
            role.RoleName = r;
            Roles.Add(role);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}