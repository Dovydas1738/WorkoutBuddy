using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutBuddy.Core.Models
{
    public class WorkoutTemplate
    {
        [Key]
        public int WorkoutTemplateId { get; set; }
        public string WorkoutName { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Exercise> Exercises { get; set; }

        public WorkoutTemplate(string workoutName, int userId)
        {
            WorkoutName = workoutName;
            UserId = userId;
            Exercises = new List<Exercise>();
        }

        public WorkoutTemplate() { }
    }
}
