using System;

namespace TrainMe.WebAPI.Models
{
    public class ProgramInstanceInputModel
    {
        public int Id { get; set; }

        public int ProgramId { get; set; }

        public int UserId { get; set; }
    }
}
