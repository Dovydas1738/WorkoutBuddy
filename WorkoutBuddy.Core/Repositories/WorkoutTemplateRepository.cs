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
    public class WorkoutTemplateRepository : IWorkoutTemplateRepository
    {
        public async Task AddAsync(WorkoutTemplate workoutTemplate)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                await context.WorkoutTemplates.AddAsync(workoutTemplate);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                var workoutTemplate = await context.WorkoutTemplates.FindAsync(id);
                if (workoutTemplate != null)
                {
                    context.WorkoutTemplates.Remove(workoutTemplate);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<WorkoutTemplate>> GetAllAsync()
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                return await context.WorkoutTemplates.ToListAsync();
            }
        }

        public async Task<WorkoutTemplate> GetByIdAsync(int id)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                var workoutTemplate = await context.WorkoutTemplates.FindAsync(id);
                if (workoutTemplate != null)
                {
                    return workoutTemplate;
                }
                throw new KeyNotFoundException($"Workout template with ID {id} was not found.");
            }
        }

        public async Task UpdateAsync(WorkoutTemplate workoutTemplate)
        {
            using (var context = new WorkoutBuddyDbContext())
            {
                context.WorkoutTemplates.Update(workoutTemplate);
                await context.SaveChangesAsync();
            }
        }
    }
}
