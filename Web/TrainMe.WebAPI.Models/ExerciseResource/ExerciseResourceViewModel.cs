using System;

namespace TrainMe.WebAPI.Models
{
    public class ExerciseResourceViewModel
    {
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        public int ResourceId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}