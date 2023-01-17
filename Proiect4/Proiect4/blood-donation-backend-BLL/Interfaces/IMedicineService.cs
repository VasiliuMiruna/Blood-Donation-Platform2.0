using blood_donation_backend.blood_donation_backend.BLL.Models;

namespace blood_donation_backend.blood_donation_backend.BLL.Interfaces
{
    public interface IMedicineService
    {
        Task Create(MedicineModel medicine);
        Task<List<MedicineModel>> GetAll();
        Task<MedicineModel> GetById(Guid id);
        Task<bool> DeleteById(Guid id);
    }
}
