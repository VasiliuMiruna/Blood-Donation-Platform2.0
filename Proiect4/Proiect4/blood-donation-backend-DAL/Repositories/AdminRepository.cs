using blood_donation_backend.blood_donation_backend.DAL.Entities;
using blood_donation_backend.Data;
using Proiect4.blood_donation_backend_DAL.Interfaces;

namespace Proiect4.blood_donation_backend_DAL.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _db;

        public AdminRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task Create(Admin admin)
        {
            await _db.Admins.AddAsync(admin);
            await _db.SaveChangesAsync();
        }
    }
}
