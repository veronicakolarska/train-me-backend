namespace TrainMe.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ExerciseInstance
    {
        [Key]
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }

        [Required]
        [Range(1, 10)]
        public int Series { get; set; }

        [Required]
        [Range(1, 30)]
        public int Repetitions { get; set; }

        [StringLength(0, MinimumLength = 20)]
        public string Tempo { get; set; }

        [Range(0, 120)]
        public int Break { get; set; }
    }
}