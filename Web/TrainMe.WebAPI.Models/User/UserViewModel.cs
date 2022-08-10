using System;
using TrainMe.Common;

namespace TrainMe.WebAPI.Models
{
    public class UserViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int? Age { get; set; }

        public Gender Gender { get; set; }
    }
}
