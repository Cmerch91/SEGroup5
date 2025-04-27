using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEGroup5.Models;

//The model defining the User class, used to represent users of the application.
//Users are assigned a role that limits their access.
[Table("Users")]
public class User
{
    public string UserID { get; set; } = ""; //ID uniqly representing the User --> String
    public string Firstname { get; set; } = ""; //User's firstname --> String
    public string Lastname { get; set; } = ""; //User's lastname --> String
    public string Email { get; set; } = ""; //User's email --> String
    public string UserRole { get; set; } = ""; //The role of the user --> String
}