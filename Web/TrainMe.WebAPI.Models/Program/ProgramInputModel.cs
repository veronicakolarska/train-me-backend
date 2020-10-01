using System;

namespace TrainMe.WebAPI.Models
{
    public class ProgramInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CreatorId { get; set; }

        public Uri Picture { get; set; }
    }
}
