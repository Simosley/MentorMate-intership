using System.ComponentModel.DataAnnotations;

namespace ResturantApi.Domain.Models
{
    public class AuthenticateRequestModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email adress")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
