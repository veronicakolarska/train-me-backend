using System;

namespace TrainMe.WebAPI.Models
{
    public class ExerciseInstanceViewModel
    {
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        public int Series { get; set; }

        public int Repetitions { get; set; }

        public string Tempo { get; set; }

        public int Break { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
