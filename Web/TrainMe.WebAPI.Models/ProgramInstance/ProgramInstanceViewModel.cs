using System;

namespace TrainMe.WebAPI.Models
{
    public class ProgramInstanceViewModel
    {
        public int Id { get; set; }

        public string ProgramName { get; set; }

        public int ProgramId { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
