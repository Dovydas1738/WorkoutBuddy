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
    public class ExerciseRepository : IExerciseRepository
    {
        public async Task AddAsync(Exercise exercise)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                await context.Exercises.AddAsync(exercise);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                var exercise = await context.Exercises.FindAsync(id);
                if (exercise != null)
                {
                    context.Exercises.Remove(exercise);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<Exercise>> GetAllByWorkoutIdAsync(int workoutId)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                return await context.Exercises
                    .Where(e => e.WorkoutId == workoutId)
                    .ToListAsync();
            }
        }

        public async Task<Exercise> GetByIdAsync(int id)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                var exercise = await context.Exercises.FindAsync(id);
                if (exercise != null)
                {
                    return exercise;
                }
                throw new KeyNotFoundException($"Exercise with ID {id} was not found.");
            }
        }

        public async Task UpdateAsync(Exercise exercise)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                context.Exercises.Update(exercise);
                await context.SaveChangesAsync();
            }
        }
    }
}
