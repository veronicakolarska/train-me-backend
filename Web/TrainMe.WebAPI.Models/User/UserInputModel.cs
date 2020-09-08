using System;

namespace TrainMe.WebAPI.Models
{
    public class UserInputModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public TrainMe.Common.Gender Gender { get; set; }
    }
}
