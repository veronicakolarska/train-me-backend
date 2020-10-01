namespace TrainMe.WebAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ExerciseResourceInputModel
    {
        [Key]
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        public int ResourceId { get; set; }
    }
}