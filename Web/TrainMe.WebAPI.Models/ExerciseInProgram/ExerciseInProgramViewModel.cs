using System;

namespace TrainMe.WebAPI.Models
{
    public class ExerciseInProgramViewModel
    {
        public int ExerciseId { get; set; }

        public int ProgramId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
