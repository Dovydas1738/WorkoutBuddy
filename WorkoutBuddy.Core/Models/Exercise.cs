using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutBuddy.Core.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }
        [ForeignKey("WorkoutId")]
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public int MinReps { get; set; }
        public int MaxReps { get; set; }
        public int CurrentReps { get; set; }
        public string? Feedback { get; set; }

        public Exercise(int workoutId, string name, int minReps, int maxReps, int currentReps)
        {
            WorkoutId = workoutId;
            Name = name;
            MinReps = minReps;
            MaxReps = maxReps;
            CurrentReps = currentReps;
        }

        public Exercise() { }
    }
}
