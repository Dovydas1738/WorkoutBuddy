using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutBuddy.Core.Models;

namespace WorkoutBuddy.Core.Contracts
{
    public interface IExerciseService
    {
        Task<Exercise> GetExerciseByIdAsync(int id);
        Task<IEnumerable<Exercise>> GetAllExercisesByWorkoutIdAsync(int workoutId);
        Task<Exercise> CreateExerciseAsync(Exercise exercise);
        Task UpdateExerciseAsync(Exercise exercise);
        Task DeleteExerciseAsync(int id);
    }
}
