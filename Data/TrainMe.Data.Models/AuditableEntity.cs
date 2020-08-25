namespace TrainMe.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AuditableEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}