using blood_donation_backend.Entities;
using Microsoft.AspNetCore.Identity;

namespace blood_donation_backend.blood_donation_backend.DAL.Entities
{
    public class AppUser : IdentityUser
    {
     
        public DateTime TokenExpiration { get; set; }

        public Donor? Donor { get; set; }
        public Admin? Admin { get; set; }
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
        public List<AppUserRefreshToken> RefreshTokens { get; set; }

       
    }
    
}
