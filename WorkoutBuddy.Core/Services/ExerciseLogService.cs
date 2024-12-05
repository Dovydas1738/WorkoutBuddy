using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutBuddy.Core.Contracts;
using WorkoutBuddy.Core.Models;

namespace WorkoutBuddy.Core.Services
{
    public class ExerciseLogService : IExerciseLogService
    {
        private readonly IExerciseLogRepository _exerciseLogRepository;

        public ExerciseLogService(IExerciseLogRepository exerciseLogRepository)
        {
            _exerciseLogRepository = exerciseLogRepository;
        }
        public async Task AddExerciseLogAsync(ExerciseLog exerciseLog)
        {
            await _exerciseLogRepository.AddAsync(exerciseLog);
        }

        public async Task<IEnumerable<ExerciseLog>> GetAllExerciseLogsAsync()
        {
            return await _exerciseLogRepository.GetAllAsync();
        }

        public async Task<ExerciseLog> GetExerciseLogByIdAsync(int id)
        {
            return await _exerciseLogRepository.GetByIdAsync(id);
        }
    }
}
