using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutBuddy.Core.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User() { }
    }
}
