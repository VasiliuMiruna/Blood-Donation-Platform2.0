using blood_donation_backend.blood_donation_backend.BLL.Models;
using blood_donation_backend.Entities;

namespace blood_donation_backend.BLL.Interfaces
{
    public interface IPatientService
    {
        //Task<List<string>> ModifyPatient();

        Task Create(PatientModel patient);
        Task<List<PatientModel>> GetAll();
        Task<PatientModel> GetById(Guid id);

        Task<bool> UpdateById(Guid id, PatientModel patient);
        Task<bool> DeleteById(Guid id);
        Task<List<MedicineModel>> GetMedicinesByPatientId(Guid patientId);
        
            
        }
}
