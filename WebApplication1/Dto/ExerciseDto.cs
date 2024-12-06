namespace WorkoutBuddy.Api.Dto
{
    public class ExerciseDto
    {
        public string Name { get; set; }
        public int Sets { get; set; }
        public int MinReps { get; set; }
        public int MaxReps { get; set; }
        public float Weight { get; set; }
        public int CurrentReps { get; set; }
    }
}
