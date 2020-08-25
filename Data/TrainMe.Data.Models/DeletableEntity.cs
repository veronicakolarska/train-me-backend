namespace TrainMe.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DeletableEntity : AuditableEntity
    {
        public DateTime DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}