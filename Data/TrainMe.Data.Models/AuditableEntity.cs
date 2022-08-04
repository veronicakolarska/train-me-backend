namespace TrainMe.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using TrainMe.Data.Common;

    public class AuditableEntity : IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}