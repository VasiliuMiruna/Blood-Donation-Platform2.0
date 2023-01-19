using blood_donation_backend.Entities;
using Microsoft.AspNetCore.Identity;

namespace blood_donation_backend.blood_donation_backend.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        //public int Id { get; set; }
    /*    public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }*/
        public DateTime TokenExpiration { get; set; }

        public Donor? Donor { get; set; }
        public Admin? Admin { get; set; }
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
        //public string? RefreshToken { get; set; }

        //public virtual ICollection<AppUserRole> UserRole { get; set; }
        //public virtual UserData UserData { get; set; }
        //public virtual ICollection<Role> AllRoles { get; set; }

        //public ICollection<UserRole> UserRoles { get; set; }


        /*        public AppUser()
                {
                    Tokens = new List<Token>();
                }*/
    }
    
}
