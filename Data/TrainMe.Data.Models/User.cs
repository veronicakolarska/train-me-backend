namespace TrainMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TrainMe.Common;

    public class User : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ExternalId { get; set; }

        [StringLength(GlobalConstants.UserNameMaxLength, MinimumLength = GlobalConstants.UserNameMinLength)]
        public string FirstName { get; set; }

        [StringLength(GlobalConstants.UserNameMaxLength, MinimumLength = GlobalConstants.UserNameMinLength)]
        public string LastName { get; set; }

        [Range(GlobalConstants.UserMinAge, GlobalConstants.UserMaxAge)]
        public int? Age { get; set; }

        public Gender Gender { get; set; } = Gender.NotSpecified;

        public ICollection<ProgramInstance> ProgramInstances { get; set; } = new HashSet<ProgramInstance>();
    }
}