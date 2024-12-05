using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutBuddy.Core.Models
{
    public class Workout
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Key]
        public int WorkoutId { get; set; }
        [ForeignKey("WorkoutTemplateId")]
        public int WorkoutTemplateId { get; set; }
        public WorkoutTemplate WorkoutTemplate { get; set; }
        public List<Exercise> Exercises { get; set; }
        public DateOnly WorkoutDate { get; set; }

        public Workout(int userId, int workoutTemplateId)
        {
            UserId = userId;
            WorkoutTemplateId = workoutTemplateId;
        }

        public Workout() { }
    }
}
