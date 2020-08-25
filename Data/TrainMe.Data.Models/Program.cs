namespace TrainMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Program
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Exercise> Exercises { get; set; }

        public string Description { get; set; }

        public int CreatorId { get; set; }

        public User Creator { get; set; }

        public ICollection<ProgramInstance> ProgramInstances { get; set; }
    }
}