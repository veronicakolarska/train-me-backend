namespace TrainMe.WebAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using TrainMe.Common;
    public class UserInputModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.UserNameMaxLength, MinimumLength = GlobalConstants.UserNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(GlobalConstants.UserNameMaxLength, MinimumLength = GlobalConstants.UserNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(GlobalConstants.UserEmailMaxLength, MinimumLength = GlobalConstants.UserEmailMinLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(GlobalConstants.UserPasswordMaxLength, MinimumLength = GlobalConstants.UserPasswordMinLength)]
        public string Password { get; set; }

        [Range(GlobalConstants.UserMinAge, GlobalConstants.UserMaxAge)]
        public int Age { get; set; }

        public Gender Gender { get; set; }
    }
}
