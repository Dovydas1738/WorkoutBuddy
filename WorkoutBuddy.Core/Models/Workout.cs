using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutBuddy.Core.Models
{
    public class Workout
    {
        public int UserId { get; set; }
        public int WorkoutId { get; set; }
        public string WorkoutType { get; set; }
        public List<Exercise> Exercises { get; set; }

        public Workout(int userId, int workoutId, string workoutType, List<Exercise> exercises)
        {
            UserId = userId;
            WorkoutId = workoutId;
            WorkoutType = workoutType;
            Exercises = exercises;
        }
    }
}
