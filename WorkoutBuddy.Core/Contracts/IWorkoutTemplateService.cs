using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutBuddy.Core.Models;

namespace WorkoutBuddy.Core.Contracts
{
    public interface IWorkoutTemplateService
    {
        public Task AddWorkoutTemplateAsync(WorkoutTemplate workoutTemplate);
        public Task DeleteWorkoutTemplateAsync(int id);
        public Task<IEnumerable<WorkoutTemplate>> GetAllWorkoutTemplatesAsync();
        public Task<WorkoutTemplate> GetWorkoutTemplateByIdAsync(int id);
        public Task UpdateWorkoutTemplateAsync(WorkoutTemplate workoutTemplate);

    }
}
