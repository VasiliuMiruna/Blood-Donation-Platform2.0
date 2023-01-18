using Microsoft.AspNetCore.Identity;

namespace blood_donation_backend.blood_donation_backend.DAL.Entities
{
    public class AppUserRole : IdentityUserRole<string>
    {
        public virtual AppUser User { get; set; }
        public virtual Role Role { get; set; }

    }
}
