using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutBuddy.Core.Models
{
    public class ExerciseLog
    {
        [Key]
        public int ExerciseLogId { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public DateOnly Date { get; set; }

        public ExerciseLog(int exerciseId, int sets, int reps, float weight, int workoutId, DateOnly date)
        {
            ExerciseId = exerciseId;
            Sets = sets;
            Reps = reps;
            Weight = weight;
            WorkoutId = workoutId;
            Date = date;
        }
    }
}
