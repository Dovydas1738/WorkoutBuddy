using WorkoutBuddy.Core.Models;
using WorkoutBuddy.Api.Dto;

namespace WorkoutBuddy.Api.Requests
{
    public class CreateWorkoutTemplateRequest
    {
        public string WorkoutName { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
    }
}
