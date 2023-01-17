using blood_donation_backend.blood_donation_backend.DAL.Entities;
using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace blood_donation_backend.blood_donation_backend.DAL.Repositories
{
   

  /*  public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthRepository(AppDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUser(AppUser user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.Email
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);

            return result;
        }

        public async Task<SignInResult> LoginUser(Login login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, lockoutOnFailure: false);

            return result;
        }

        public async Task LogoutUser()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityUser> GetUserByName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            return user;
        }
    }*/
}
