using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutBuddy.Core.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public ICollection<WorkoutTemplate> WorkoutTemplates { get; set; }
        public ICollection<Workout> Workouts { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            WorkoutTemplates = new List<WorkoutTemplate>();
            Workouts = new List<Workout>();
        }

        public User() { }
    }
}
