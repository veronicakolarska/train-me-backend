using System;
using TrainMe.Data.Common.Enums;

namespace TrainMe.WebAPI.Models
{
    public class ProgramViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CreatorId { get; set; }

        public Uri Picture { get; set; }

        public DifficultyLevel Difficulty { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int Duration { get; set; }

        public bool IsUserEnrolled { get; set; }
    }
}
