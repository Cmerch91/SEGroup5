using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEGroup5.Models;

//The model defining the Role class, used for assigning and limiting user access.
[Table("Roles")]
public class Role
{
    public string RoleName { get; set; } = ""; //Name of the role
}