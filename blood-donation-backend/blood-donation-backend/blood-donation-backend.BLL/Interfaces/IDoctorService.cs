using blood_donation_backend.blood_donation_backend.BLL.Models;

namespace blood_donation_backend.blood_donation_backend.BLL.Interfaces
{
    public interface IDoctorService
    {
        Task Create(DoctorModel doctor);
        Task<List<DoctorModel>> GetAll();
        Task<DoctorModel> GetById(Guid id);

        Task UpdateById(DoctorModel doctor);
       // Task DeleteById(Guid id);
    }
}
