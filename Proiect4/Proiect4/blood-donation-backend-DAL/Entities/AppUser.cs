using Microsoft.AspNetCore.Identity;

namespace blood_donation_backend.blood_donation_backend.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }

        //public virtual ICollection<Role> AllRoles { get; set; }

        //public ICollection<UserRole> UserRoles { get; set; }


        /*        public AppUser()
                {
                    Tokens = new List<Token>();
                }*/
    }
    
}
