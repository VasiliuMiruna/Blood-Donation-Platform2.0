using blood_donation_backend.Entities;

namespace blood_donation_backend.blood_donation_backend.DAL.Interfaces
{
    public interface IPatientRepository
    {
         Task Create(Patient patient);
         Task<List<Patient>> GetAll();
         Task<Patient> GetById(Guid id);
         Task UpdatePatient(Patient patient);
         Task<List<Medicine>> GetMedicinesByPatientId(Guid patientId);
        Task DeletePatient(Patient patient);
     //    Task DeletePatient(Patient patient);

        /*  void Update(Patient patient);
void Delete(Patient patient);*/
    }
}
