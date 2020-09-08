using System;

namespace TrainMe.WebAPI.Models
{
    public class ResourceViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TrainMe.Common.ResourceType Type { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}