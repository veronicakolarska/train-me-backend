using System;

namespace TrainMe.WebAPI.Models
{
    public class ResourceInputModel
    {
        public string Name { get; set; }

        public TrainMe.Common.ResourceType Type { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }
    }
}