namespace TrainMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TrainMe.Common;

    public class Exercise : AuditableEntity
    {
        public Exercise()
        {
            this.Resources = new HashSet<Resource>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.ExerciseNameMaxLength, MinimumLength = GlobalConstants.ExerciseNameMinLength)]
        public string Name { get; set; }

        [Required]
        [Range(GlobalConstants.ExerciseSeriesMin, GlobalConstants.ExerciseSeriesMax)]
        public int SeriesDefault { get; set; }

        [Required]
        [Range(GlobalConstants.ExerciseRepetitionsMin, GlobalConstants.ExerciseRepetitionsMax)]
        public int RepetitionsDefault { get; set; }

        [StringLength(GlobalConstants.ExerciseTempoMaxLength, MinimumLength = GlobalConstants.ExerciseTempoMinLength)]
        public string TempoDefault { get; set; }

        [Range(GlobalConstants.ExerciseBreakMin, GlobalConstants.ExerciseBreakMax)]
        public int BreakDefault { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }
}