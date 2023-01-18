using blood_donation_backend.blood_donation_backend.DAL.Entities;

namespace Proiect4.blood_donation_backend_DAL.Interfaces
{
    public interface IAdminRepository
    {
        Task Create(Admin admin);
    }
}
