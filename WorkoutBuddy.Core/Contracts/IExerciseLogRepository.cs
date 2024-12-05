using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutBuddy.Core.Models;

namespace WorkoutBuddy.Core.Contracts
{
    public interface IExerciseLogRepository
    {
        public Task AddAsync(ExerciseLog exerciseLog);
        public Task<IEnumerable<ExerciseLog>> GetAllAsync();
        public Task<ExerciseLog> GetByIdAsync(int id);
    }
}
