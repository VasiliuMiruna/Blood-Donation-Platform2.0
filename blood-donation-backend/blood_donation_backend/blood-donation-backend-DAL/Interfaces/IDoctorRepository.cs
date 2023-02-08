using blood_donation_backend.Entities;

namespace blood_donation_backend.blood_donation_backend.DAL.Interfaces
{
    public interface IDoctorRepository
    {
        Task Create(Doctor doctor);
        Task<List<Doctor>> GetAll();
        Task<Doctor> GetById(Guid id);
        Task<Doctor> GetByUserId(string id);
        Task UpdateDoctor(Doctor doctor);
        Task DeleteDoctor(Doctor doctor);
       
    }
}
