namespace TrainMe.Data.Common.Models
{
    using System;

    public class AuditableEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}