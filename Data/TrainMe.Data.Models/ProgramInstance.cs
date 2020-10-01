namespace TrainMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProgramInstance : AuditableEntity
    {
        public ProgramInstance()
        {
            this.ExerciseInstancesInProgramInstance = new HashSet<ExerciseInstanceInProgramInstance>();
        }

        [Key]
        public int Id { get; set; }

        public int ProgramId { get; set; }

        public Program Program { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<ExerciseInstanceInProgramInstance> ExerciseInstancesInProgramInstance { get; set; }
    }
}