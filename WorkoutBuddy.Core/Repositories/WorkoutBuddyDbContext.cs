using Microsoft.EntityFrameworkCore;
using WorkoutBuddy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutBuddy.Core.Repositories
{
    public class WorkoutBuddyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=WorkoutBuddy;Trusted_Connection=True;TrustServerCertificate=true;");
        }
    }
}
