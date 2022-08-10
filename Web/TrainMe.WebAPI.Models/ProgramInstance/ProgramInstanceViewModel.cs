using System;

namespace TrainMe.WebAPI.Models
{
    public class ProgramInstanceViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public string ProgramName { get; set; }

        public int ProgramId { get; set; }

        public int UserId { get; set; }
    }
}
