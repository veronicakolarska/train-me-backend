namespace TrainMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TrainMe.Common;

    public class Resource : AuditableEntity
    {
        public Resource()
        {
            this.Exercises = new HashSet<ExerciseResource>();
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

        public ICollection<ExerciseResource> Exercises { get; set; }
    }
}