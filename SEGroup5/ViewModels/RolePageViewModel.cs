using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using SEGroup5.Models;

namespace SEGroup5.ViewModels;

public class RolePageViewModel : ObservableObject
{

    private Models.Role _role;

    private string newName = "";

    public ICommand SaveCommand { get; private set; }
    public ICommand DeleteCommand { get; private set; }

    public RolePageViewModel()
    {
        _role = new Role();
        SaveCommand = new AsyncRelayCommand(SaveRole);
        DeleteCommand = new AsyncRelayCommand(DeleteRole);
    }

    public RolePageViewModel(Role role)
    {
        _role = role;
        SaveCommand = new AsyncRelayCommand(SaveRole);
        DeleteCommand = new AsyncRelayCommand(DeleteRole);
    }

    private async Task SaveRole()
    {
        var sql = new SQLConnection();

        await sql.UpdateRole(_role, newName);
    }

    private async Task DeleteRole()
    {
        var sql = new SQLConnection();

        await sql.DeleteRole(_role);
    }

}