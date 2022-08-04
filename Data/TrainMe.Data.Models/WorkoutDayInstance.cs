namespace TrainMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class WorkoutDayInstance
    {
        [Key]
        public int Id { get; set; }

        public int Order { get; set; }

        public bool IsRestDay { get; set; }

        public int ProgramInstanceId { get; set; }

        public ProgramInstance ProgramInstance { get; set; }

        public int WorkoutDayId { get; set; }

        public WorkoutDay WorkoutDay { get; set; }

        public ICollection<ExerciseInstanceInWorkoutDayInstance> ExerciseInstancesInWorkoutDayInstances { get; set; } = new HashSet<ExerciseInstanceInWorkoutDayInstance>();
    }
}
