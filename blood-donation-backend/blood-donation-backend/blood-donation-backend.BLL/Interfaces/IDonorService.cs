using blood_donation_backend.blood_donation_backend.BLL.Models;

namespace blood_donation_backend.blood_donation_backend.BLL.Interfaces
{
    public interface IDonorService
    {
        Task Create(DonorModel donor);
        Task<List<DonorModel>> GetAll();
        Task<DonorModel> GetById(Guid id);

        Task UpdateById(DonorModel donor);
        Task<List<PatientModel>> GetPatientsOfDonors(Guid donorId);
        Task<List<DonorModel>> GetDonorsByBloodType(string bloodType);
    }
}
