namespace TrainMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using TrainMe.Common;
    using System.ComponentModel.DataAnnotations;

    public class ExerciseInstanceInProgramInstance : AuditableEntity
    {
        public int ExerciseInstanceId { get; set; }

        public ExerciseInstance ExerciseInstance { get; set; }

        public int ProgramInstanceId { get; set; }

        public ProgramInstance ProgramInstance { get; set; }
    }
}