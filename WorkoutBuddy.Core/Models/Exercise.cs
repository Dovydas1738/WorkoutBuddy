using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutBuddy.Core.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public int MinReps { get; set; }
        public int MaxReps { get; set; }
        public int CurrentReps { get; set; }
        public string Feedback { get; set; }

        public Exercise(int workoutId, string name, int minReps, int maxReps, int currentReps)
        {
            WorkoutId = workoutId;
            Name = name;
            MinReps = minReps;
            MaxReps = maxReps;
            CurrentReps = currentReps;
        }
    }
}
