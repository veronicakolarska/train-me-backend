namespace TrainMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TrainMe.Common;

    public class Exercise : AuditableEntity
    {
        public Exercise()
        {
            this.ExerciseResources = new HashSet<ExerciseResource>();
            this.ExerciseInstances = new HashSet<ExerciseInstance>();
            this.ExercisesInProgram = new HashSet<ExerciseInProgram>();
        }

        [Key]
        public int Id { get; set; }

        public int ProgramId { get; set; }

        public Program Program { get; set; }

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

        public ICollection<ExerciseResource> ExerciseResources { get; set; }

        public ICollection<ExerciseInstance> ExerciseInstances { get; set; }

        public ICollection<ExerciseInProgram> ExercisesInProgram { get; set; }
    }
}