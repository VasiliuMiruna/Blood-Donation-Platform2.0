using blood_donation_backend.blood_donation_backend.DAL.Entities;
using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace blood_donation_backend.blood_donation_backend.DAL.Repositories
{


    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

    }
}
