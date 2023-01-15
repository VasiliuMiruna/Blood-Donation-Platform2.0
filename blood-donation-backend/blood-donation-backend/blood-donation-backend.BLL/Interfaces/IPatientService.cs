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

        Task UpdateById(PatientModel patient);
        Task DeleteById(Guid id);
        Task<List<MedicineModel>> GetMedicinesByPatientId(Guid patientId);
        
            /*   void Update(PatientModel patient);
               void Delete(PatientModel patient);*/

            // Task<PatientModel> GetById(int id);
            //Task Update(PatientModel patient);
        }
}
