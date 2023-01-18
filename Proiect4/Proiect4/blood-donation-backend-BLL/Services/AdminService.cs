using blood_donation_backend.blood_donation_backend.DAL.Entities;
using Proiect4.blood_donation_backend_BLL.Models;
using Proiect4.blood_donation_backend_DAL.Interfaces;

namespace Proiect4.blood_donation_backend_BLL.Services
{
    public class AdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task Create(AdminModel admin)
        {
            admin.Id = new Guid();
            var newAdmin = new Admin
            {
                AdminId = (Guid)admin.Id,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                
                
            };

            await _adminRepository.Create(newAdmin);

        }
    }
}
