using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using SEGroup5.Models;

namespace SEGroup5.ViewModels;

public class UserPageViewModel : ObservableObject
{
    private User _user;

    public ICommand SaveUserCommand { get; private set; }
    public ICommand DeleteUserCommand { get; private set; }

    public UserPageViewModel()
    {
        _user = new User();
        SaveUserCommand = new AsyncRelayCommand(Save);
        DeleteUserCommand = new AsyncRelayCommand(Delete);
    }

    public UserPageViewModel(User user)
    {
        _user = user;
        SaveUserCommand = new AsyncRelayCommand(Save);
        DeleteUserCommand = new AsyncRelayCommand(Delete);
    }

    private async Task Save()
    {
        //_user.SaveUser();
    }

    private async Task Delete()
    {
        //_user.DeleteUser();
    }
}