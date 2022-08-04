namespace TrainMe.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using TrainMe.Data.Common.Models;

    public class DeletableEntity : AuditableEntity, IDeletableEntity
    {
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}