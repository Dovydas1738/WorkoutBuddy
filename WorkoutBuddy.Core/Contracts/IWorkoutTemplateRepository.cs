using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutBuddy.Core.Models;

namespace WorkoutBuddy.Core.Contracts
{
    public interface IWorkoutTemplateRepository
    {
        public Task AddAsync(WorkoutTemplate workoutTemplate);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<WorkoutTemplate>> GetAllAsync();
        public Task<WorkoutTemplate> GetByIdAsync(int id);
        public Task UpdateAsync(WorkoutTemplate workoutTemplate);
    }
}
