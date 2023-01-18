using blood_donation_backend.blood_donation_backend.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Proiect4.blood_donation_backend_DAL
{
    public class InitialSeed
    {
        public readonly RoleManager<IdentityRole> _roleManager;

        public InitialSeed(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async void CreateRoles()
        {
            string[] roleNames =
            {
                "Admin",
                "Patient",
                "Doctor",
                "Donor"
            };

            foreach (var roleName in roleNames)
            {
                var role = new IdentityRole
                {
                    Name = roleName
                };

                await _roleManager.CreateAsync(role);
            }
        }
    }
}
