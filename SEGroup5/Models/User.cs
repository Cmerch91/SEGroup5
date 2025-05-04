using System;

namespace SEGroup5.Models;

//The model defining the User class, used to represent users of the application.
//Users are assigned a role that limits their access.
public class User
{
    public string UserID { get; set; } = ""; //ID uniqly representing the User
    public string UserRole { get; set; } = ""; //The role of the user
    public string Firstname { get; set; } = ""; //User's firstname
    public string Lastname { get; set; } = ""; //User's lastname
    public string Email { get; set; } = ""; //User's email
    public string Password {get; set; } = ""; //The password of the user
}