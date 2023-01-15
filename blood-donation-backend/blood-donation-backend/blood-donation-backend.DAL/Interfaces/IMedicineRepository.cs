using blood_donation_backend.Entities;

namespace blood_donation_backend.blood_donation_backend.DAL.Interfaces
{
    public interface IMedicineRepository
    {
        Task Create(Medicine medicine);
        Task<List<Medicine>> GetAll();
    }
}
