using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutBuddy.Core.Contracts;
using WorkoutBuddy.Core.Models;
using WorkoutBuddy.Core.Repositories;

namespace WorkoutBuddy.Core.Services
{
    public class WorkoutTemplateService : IWorkoutTemplateService
    {
        private readonly IWorkoutTemplateRepository _workoutTemplateRepository;

        public WorkoutTemplateService(IWorkoutTemplateRepository workoutTemplateRepository)
        {
            _workoutTemplateRepository = workoutTemplateRepository;
        }

        public async Task AddWorkoutTemplateAsync(WorkoutTemplate workoutTemplate)
        {
            await _workoutTemplateRepository.AddAsync(workoutTemplate);
        }

        public async Task DeleteWorkoutTemplateAsync(int id)
        {
            await _workoutTemplateRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<WorkoutTemplate>> GetAllWorkoutTemplatesAsync()
        {
            return await _workoutTemplateRepository.GetAllAsync();
        }

        public async Task<WorkoutTemplate> GetWorkoutTemplateByIdAsync(int id)
        {
            return await _workoutTemplateRepository.GetByIdAsync(id);
        }

        public async Task UpdateWorkoutTemplateAsync(WorkoutTemplate workoutTemplate)
        {
            await _workoutTemplateRepository.UpdateAsync(workoutTemplate);
        }
    }
}
