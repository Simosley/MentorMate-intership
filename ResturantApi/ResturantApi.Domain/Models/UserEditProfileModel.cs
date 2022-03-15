using System.ComponentModel.DataAnnotations;

namespace ResturantApi.Domain.Models
{
    public class UserEditProfileModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [StringLength(64, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string Password { get; set; }
        [Url]
        public string ImageUrl { get; set; }
    }
}
