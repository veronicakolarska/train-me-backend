using System;

namespace TrainMe.WebAPI.Models
{
    public class ExerciseInstanceInProgramInstanceViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public int ExerciseInstanceId { get; set; }

        public int ProgramInstanceId { get; set; }
    }
}