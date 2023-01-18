using Microsoft.AspNetCore.Identity;

namespace blood_donation_backend.blood_donation_backend.DAL.Entities
{
    public class Role : IdentityRole<string>
    {
        public string Name { get; set; }
        //public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
