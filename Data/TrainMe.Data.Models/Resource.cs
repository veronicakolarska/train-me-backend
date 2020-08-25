namespace TrainMe.Data.Models
{
    using System;
    using TrainMe.Common;
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.ResourceNameMaxLength, MinimumLength = GlobalConstants.ResourceNameMinLength)]
        public string Name { get; set; }

        [Required]
        public ResourceType Type { get; set; }

        [StringLength(GlobalConstants.ResourceDescriptionMaxLength)]
        public string Description { get; set; }
    }
}