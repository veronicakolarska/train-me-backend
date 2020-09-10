using System;
using TrainMe.Common;

namespace TrainMe.WebAPI.Models
{
    public class ResourceInputModel
    {
        public string Name { get; set; }

        public ResourceType Type { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }
    }
}