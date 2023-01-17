using System.ComponentModel.DataAnnotations;

namespace blood_donation_backend.blood_donation_backend.BLL.Models
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
