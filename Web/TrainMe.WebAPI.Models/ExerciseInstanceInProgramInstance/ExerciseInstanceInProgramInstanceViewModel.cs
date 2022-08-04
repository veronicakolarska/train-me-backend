using System;

namespace TrainMe.WebAPI.Models
{
    public class ExerciseInstanceInProgramInstanceViewModel
    {
        public int Id { get; set; }

        public int ExerciseInstanceId { get; set; }

        public int ProgramInstanceId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}