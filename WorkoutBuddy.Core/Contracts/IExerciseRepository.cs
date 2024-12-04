using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutBuddy.Core.Models;

namespace WorkoutBuddy.Core.Contracts
{
    public interface IExerciseRepository
    {
        Task<Exercise> GetByIdAsync(int id);
        Task<IEnumerable<Exercise>> GetAllByWorkoutIdAsync(int workoutId);
        Task AddAsync(Exercise exercise);
        Task UpdateAsync(Exercise exercise);
        Task DeleteAsync(int id);
    }
}
