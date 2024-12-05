using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutBuddy.Core.Contracts;
using WorkoutBuddy.Core.Models;

namespace WorkoutBuddy.Core.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        public async Task AddAsync(Workout workout)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                await context.Workouts.AddAsync(workout);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                var workout = await context.Workouts.FindAsync(id);
                if (workout != null)
                {
                    context.Workouts.Remove(workout);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<Workout>> GetAllAsync()
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                return await context.Workouts.ToListAsync();
            }
        }

        public async Task<Workout> GetByIdAsync(int id)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                var workout = await context.Workouts.FindAsync(id);
                if (workout != null)
                {
                    return workout;
                }
                throw new KeyNotFoundException($"Workout with ID {id} was not found.");
            }
        }

        public async Task UpdateAsync(Workout workout)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                context.Workouts.Update(workout);
                await context.SaveChangesAsync();
            }
        }
    }
}
