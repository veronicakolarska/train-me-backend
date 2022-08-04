namespace TrainMe.Data.Models
{
    public class ExerciseInstanceInWorkoutDayInstance : AuditableEntity
    {
        public int ExerciseInstanceId { get; set; }

        public ExerciseInstance ExerciseInstance { get; set; }

        public int WorkoutDayInstanceId { get; set; }

        public WorkoutDayInstance WorkoutDayInstance { get; set; }
    }
}