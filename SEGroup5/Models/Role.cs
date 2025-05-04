using System;
using Microsoft.EntityFrameworkCore;

namespace SEGroup5.Models;

//The model defining the Role class, used for assigning and limiting user access.
public class Role
{
    public string RoleName { get; set; } = ""; //Name of the role
}