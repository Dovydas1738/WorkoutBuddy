using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutBuddy.Core.Models;

namespace WorkoutBuddy.Core.Contracts
{
    public interface IWorkoutService
    {
        Task<Workout> GetWorkoutByIdAsync(int id);
        Task<IEnumerable<Workout>> GetAllWorkoutsAsync();
        Task<Workout> AddWorkoutAsync(Workout workout);
        Task UpdateWorkoutAsync(Workout workout);
        Task DeleteWorkoutAsync(int id);
    }
}
