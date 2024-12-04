using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutBuddy.Core.Contracts;
using WorkoutBuddy.Core.Models;

namespace WorkoutBuddy.Core.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<Exercise> CreateExerciseAsync(Exercise exercise)
        {
            await _exerciseRepository.AddAsync(exercise);
            return exercise;
        }

        public async Task DeleteExerciseAsync(int id)
        {
            await _exerciseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Exercise>> GetAllExercisesByWorkoutIdAsync(int workoutId)
        {
            return await _exerciseRepository.GetAllByWorkoutIdAsync(workoutId);
        }

        public async Task<Exercise> GetExerciseByIdAsync(int id)
        {
            return await _exerciseRepository.GetByIdAsync(id);
        }

        public async Task UpdateExerciseAsync(Exercise exercise)
        {
            await _exerciseRepository.UpdateAsync(exercise);
        }
    }
}
