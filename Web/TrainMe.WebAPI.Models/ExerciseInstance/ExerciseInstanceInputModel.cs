namespace TrainMe.WebAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using TrainMe.Common;

    public class ExerciseInstanceInputModel
    {
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        public int ProgramInstanceId { get; set; }

        [Required]
        [Range(GlobalConstants.ExerciseSeriesMin, GlobalConstants.ExerciseSeriesMax)]
        public int Series { get; set; }

        [Required]
        [Range(GlobalConstants.ExerciseRepetitionsMin, GlobalConstants.ExerciseRepetitionsMax)]
        public int Repetitions { get; set; }

        [StringLength(GlobalConstants.ExerciseTempoMaxLength, MinimumLength = GlobalConstants.ExerciseTempoMinLength)]
        public string Tempo { get; set; }

        [Range(GlobalConstants.ExerciseBreakMin, GlobalConstants.ExerciseBreakMax)]
        public int Break { get; set; }
    }
}
