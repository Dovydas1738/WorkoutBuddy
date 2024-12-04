using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutBuddy.Core.Models;

namespace WorkoutBuddy.Core.Contracts
{
    public interface IWorkoutRepository
    {
        Task<Workout> GetByIdAsync(int id);
        Task<IEnumerable<Workout>> GetAllAsync();
        Task AddAsync(Workout workout);
        Task UpdateAsync(Workout workout);
        Task DeleteAsync(int id);
    }
}
