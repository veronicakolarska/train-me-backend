namespace TrainMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class WorkoutDay : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int Order { get; set; }

        public bool IsRestDay { get; set; }

        public int ProgramId { get; set; }

        public Program Program { get; set; }

        public ICollection<ExerciseInWorkoutDay> ExercisesInWorkoutDay { get; set; } = new HashSet<ExerciseInWorkoutDay>();

        public ICollection<WorkoutDayInstance> WorkoutDayInstances { get; set; } = new HashSet<WorkoutDayInstance>();
    }
}
