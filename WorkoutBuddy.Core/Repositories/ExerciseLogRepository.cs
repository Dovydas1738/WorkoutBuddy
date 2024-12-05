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
    public class ExerciseLogRepository : IExerciseLogRepository
    {
        public async Task AddAsync(ExerciseLog exerciseLog)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                await context.ExerciseLogs.AddAsync(exerciseLog);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ExerciseLog>> GetAllAsync()
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                return await context.ExerciseLogs.ToListAsync();
            }
        }

        public async Task<ExerciseLog> GetByIdAsync(int id)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                var exerciseLog = await context.ExerciseLogs.FindAsync(id);
                if (exerciseLog != null)
                {
                    return exerciseLog;
                }
                throw new KeyNotFoundException($"Exercise log with ID {id} was not found.");
            }
        }
    }
}
