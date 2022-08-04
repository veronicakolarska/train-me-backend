namespace TrainMe.Data.Models
{
    public class ExerciseResource : AuditableEntity
    {
        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }

        public int ResourceId { get; set; }

        public Resource Resource { get; set; }
    }
}