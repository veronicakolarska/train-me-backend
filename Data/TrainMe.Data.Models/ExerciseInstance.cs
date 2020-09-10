namespace TrainMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using TrainMe.Common;
    using System.ComponentModel.DataAnnotations;


    public class ExerciseInstance : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }

        public int ProgramInstanceId { get; set; }

        public ProgramInstance ProgramInstance { get; set; }

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