namespace TrainMe.WebAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ExerciseInstanceInProgramInstanceInputModel
    {
        public int Id { get; set; }

        public int ExerciseInstanceId { get; set; }

        public int ProgramInstanceId { get; set; }
    }
}