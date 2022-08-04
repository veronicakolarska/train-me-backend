namespace TrainMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using TrainMe.Common;
    using TrainMe.Data.Common.Enums;

    public class Program : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.ProgramNameMaxLength, MinimumLength = GlobalConstants.ProgramNameMinLength)]
        public string Name { get; set; }

        [StringLength(GlobalConstants.ProgramDescriptionMaxLength)]
        public string Description { get; set; }

        public int CreatorId { get; set; }

        public User Creator { get; set; }

        public Uri Picture { get; set; }

        public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Easy;

        public ICollection<ProgramInstance> ProgramInstances { get; set; } = new HashSet<ProgramInstance>();

        public ICollection<WorkoutDay> WorkoutDays { get; set; } = new HashSet<WorkoutDay>();
    }
}