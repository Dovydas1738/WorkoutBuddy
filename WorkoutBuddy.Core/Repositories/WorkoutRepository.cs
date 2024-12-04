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
        private readonly WorkoutBuddyDbContext _context;

        public WorkoutRepository(WorkoutBuddyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Workout workout)
        {
            await _context.Workouts.AddAsync(workout);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout != null)
            {
                _context.Workouts.Remove(workout);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Workout>> GetAllAsync()
        {
            return await _context.Workouts.ToListAsync();
        }

        public async Task<Workout> GetByIdAsync(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout != null)
            {
                return workout;
            }
            throw new KeyNotFoundException($"Workout with ID {id} was not found.");

        }

        public async Task UpdateAsync(Workout workout)
        {
            _context.Workouts.Update(workout);
            await _context.SaveChangesAsync();
        }
    }
}
