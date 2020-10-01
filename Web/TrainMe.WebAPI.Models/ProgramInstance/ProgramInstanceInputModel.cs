namespace TrainMe.WebAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProgramInstanceInputModel
    {
        [Key]
        public int Id { get; set; }

        public int ProgramId { get; set; }

        public int UserId { get; set; }
    }
}
