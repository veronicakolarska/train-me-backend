using System;

namespace TrainMe.WebAPI.Models
{
    public class ExerciseViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SeriesDefault { get; set; }

        public int RepetitionsDefault { get; set; }

        public string TempoDefault { get; set; }

        public int BreakDefault { get; set; }
    }
}
