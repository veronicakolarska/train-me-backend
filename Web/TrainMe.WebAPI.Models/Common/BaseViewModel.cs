using System;

namespace TrainMe.WebAPI.Models
{
    public abstract class BaseViewModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
