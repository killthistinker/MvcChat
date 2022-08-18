using System;
using Microsoft.AspNetCore.Identity;

namespace homework_64.Models
{
    public class User : IdentityUser<int>
    {
        public DateTime DateOfBirth { get; set; }
        public string Avatar { get; set; }
        public bool Block  { get; set; }
    }
}