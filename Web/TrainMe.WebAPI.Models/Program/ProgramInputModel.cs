using System;

namespace TrainMe.WebAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using TrainMe.Common;

    public class ProgramInputModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.ProgramNameMaxLength, MinimumLength = GlobalConstants.ProgramNameMinLength)]
        public string Name { get; set; }

        [StringLength(GlobalConstants.ProgramDescriptionMaxLength)]
        public string Description { get; set; }

        public int CreatorId { get; set; }

        public Uri Picture { get; set; }
    }
}
