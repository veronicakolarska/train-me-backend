namespace TrainMe.Data.Common.Models
{
    using System;

    public class DeletableEntity : AuditableEntity
    {
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}