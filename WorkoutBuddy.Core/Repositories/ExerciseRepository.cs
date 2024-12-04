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
        private readonly WorkoutBuddyDbContext _context;

        public ExerciseRepository(WorkoutBuddyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Exercise>> GetAllByWorkoutIdAsync(int workoutId)
        {
            return await _context.Exercises
                .Where(e => e.WorkoutId == workoutId)
                .ToListAsync();
        }

        public async Task<Exercise> GetByIdAsync(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise != null)
            {
                return exercise;
            }
            throw new KeyNotFoundException($"Exercise with ID {id} was not found.");
        }

        public async Task UpdateAsync(Exercise exercise)
        {
            _context.Exercises.Update(exercise);
            await _context.SaveChangesAsync();
        }
    }
}
