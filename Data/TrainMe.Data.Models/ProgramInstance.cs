namespace TrainMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProgramInstance
    {
        public ProgramInstance()
        {
            this.ExerciseInstances = new HashSet<ExerciseInstance>();
        }

        [Key]
        public int Id { get; set; }

        public int ProgramId { get; set; }

        public Program Program { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<ExerciseInstance> ExerciseInstances { get; set; }
    }
}