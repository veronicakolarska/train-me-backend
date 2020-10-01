namespace TrainMe.Data.Models
{
    using System;
    using TrainMe.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Program : AuditableEntity
    {
        public Program()
        {
            this.ProgramInstances = new HashSet<ProgramInstance>();
            this.ExercisesInProgram = new HashSet<ExerciseInProgram>();
        }

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

        public ICollection<ProgramInstance> ProgramInstances { get; set; }

        public ICollection<ExerciseInProgram> ExercisesInProgram { get; set; }
    }
}