namespace TrainMe.Data.Models
{
    using System;

    public class ExerciseInWorkoutDay : AuditableEntity
    {
        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }

        public int WorkoutDayId { get; set; }

        public WorkoutDay WorkoutDay { get; set; }
    }
}