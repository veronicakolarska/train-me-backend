using System;

namespace TrainMe.WebAPI.Models
{
    public class ExerciseResourceInputModel
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }

        public int ResourceId { get; set; }
    }
}