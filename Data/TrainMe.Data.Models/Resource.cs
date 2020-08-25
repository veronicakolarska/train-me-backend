namespace TrainMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using TrainMe.Common;
    using System.ComponentModel.DataAnnotations;

    public class Resource : AuditableEntity
    {
        public Resource()
        {
            this.Exercises = new HashSet<Exercise>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.ResourceNameMaxLength, MinimumLength = GlobalConstants.ResourceNameMinLength)]
        public string Name { get; set; }

        [Required]
        public ResourceType Type { get; set; }

        [Required]
        public string Link { get; set; }

        [StringLength(GlobalConstants.ResourceDescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}