using System;

namespace TrainMe.WebAPI.Models
{
    public class ExerciseInProgramViewModel : BaseViewModel
    {
        public int ExerciseId { get; set; }

        public int ProgramId { get; set; }
    }
}
