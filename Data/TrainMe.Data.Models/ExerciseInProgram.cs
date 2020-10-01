namespace TrainMe.Data.Models
{
    public class ExerciseInProgram : AuditableEntity
    {
        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }

        public int ProgramId { get; set; }

        public Program Program { get; set; }
    }
}