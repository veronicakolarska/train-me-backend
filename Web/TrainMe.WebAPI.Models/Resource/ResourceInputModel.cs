namespace TrainMe.WebAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using TrainMe.Common;

    public class ResourceInputModel
    {
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
    }
}