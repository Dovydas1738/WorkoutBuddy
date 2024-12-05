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
        [ForeignKey("WorkoutTemplateId")]
        public int WorkoutTemplateId { get; set; }
        public WorkoutTemplate WorkoutTemplate { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int MinReps { get; set; }
        public int MaxReps { get; set; }
        public float Weight { get; set; }
        public int CurrentReps { get; set; }
        public string? Feedback { get; set; }

        public Exercise(int workoutTemplateId, string name, int sets, int minReps, int maxReps, float weight, int currentReps)
        {
            WorkoutTemplateId = workoutTemplateId;
            Name = name;
            Sets = sets;
            MinReps = minReps;
            MaxReps = maxReps;
            Weight = weight;
            CurrentReps = currentReps;
        }

        public Exercise() { }
    }
}
