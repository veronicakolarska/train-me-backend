namespace TrainMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Program
    {
        public Program()
        {
            this.Exercises = new HashSet<Exercise>();
            this.ProgramInstances = new HashSet<ProgramInstance>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int CreatorId { get; set; }

        public User Creator { get; set; }

        public ICollection<Exercise> Exercises { get; set; }

        public ICollection<ProgramInstance> ProgramInstances { get; set; }
    }
}