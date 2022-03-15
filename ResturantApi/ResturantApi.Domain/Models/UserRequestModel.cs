using ResturantApi.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ResturantApi.Domain.Models
{
    public class UserRequestModel
    {

        [Required]
        public Role Role { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email adress")]
        public string Email { get; set; } = string.Empty;

        [StringLength(64, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
