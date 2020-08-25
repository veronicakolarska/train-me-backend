namespace TrainMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Exercise
    {
        public Exercise()
        {
            this.Resources = new HashSet<Resource>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(1, 10)]
        public int SeriesDefault { get; set; }

        [Required]
        [Range(1, 30)]
        public int RepetitionsDefault { get; set; }

        [StringLength(0, MinimumLength = 20)]
        public string TempoDefault { get; set; }

        [Range(0, 120)]
        public int BreakDefault { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }
}