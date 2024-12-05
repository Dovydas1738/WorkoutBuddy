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
        public DbSet<WorkoutTemplate> WorkoutTemplates { get; set; }
        public DbSet<ExerciseLog> ExerciseLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=WorkoutBuddy;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Workout>()
                .HasOne(w => w.WorkoutTemplate)
                .WithMany()
                .HasForeignKey(w => w.WorkoutTemplateId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ExerciseLog>()
                .HasOne(w => w.Workout)
                .WithMany()
                .HasForeignKey(w => w.WorkoutId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
