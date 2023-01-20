using System.ComponentModel.DataAnnotations;

namespace blood_donation_backend.blood_donation_backend.DAL.Entities
{
    public class AppUserRefreshToken
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; } 

        [Required]
        public string RefreshToken { get; set; }
    }
}
