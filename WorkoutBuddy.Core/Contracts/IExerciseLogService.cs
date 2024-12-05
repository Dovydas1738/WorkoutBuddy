using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutBuddy.Core.Models;

namespace WorkoutBuddy.Core.Contracts
{
    public interface IExerciseLogService
    {
        public Task AddExerciseLogAsync(ExerciseLog exerciseLog);
        public Task<IEnumerable<ExerciseLog>> GetAllExerciseLogsAsync();
        public Task<ExerciseLog> GetExerciseLogByIdAsync(int id);
    }
}
