namespace TrainMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public ResourceType Type { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
    }
}