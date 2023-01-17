using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Data;
using blood_donation_backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace blood_donation_backend.blood_donation_backend.DAL.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _db;

        public PatientRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task Create(Patient patient)
        {
            await _db.Patients.AddAsync(patient);
            await _db.SaveChangesAsync();
        }



        public async Task<List<Patient>> GetAll()
        {
            return _db.Patients.ToList();
            
        }

        public async Task<Patient> GetById(Guid id)
        {
            return _db.Patients.FirstOrDefault(p => p.PatientId == id);
            

        }

        public async Task UpdatePatient(Patient patient)
        {
            _db.Patients.Update(patient);
            await _db.SaveChangesAsync();
        }

        
       
        public async Task DeletePatient(Patient patient)
        {
            _db.Patients.Remove(patient);
            await _db.SaveChangesAsync();
           
            
        }
        /*  public async Task<List<Medicine>> GetMedicinesByPatientId(Guid patientId)
          {
              var medicines = await _db.PatientMedicines
                  .Where(pm => pm.PatientId == patientId)
                  .Select(pm => pm.Medicine)
                  .ToListAsync();
              return medicines;
          }*/

        public async Task<List<Medicine>> GetMedicinesByPatientId(Guid patientId)
        {
            var medicines = await _db.PatientMedicines
                .Where(pm => pm.PatientId == patientId)
                .GroupBy(pm => pm.Medicine)
                .Select(group => group.Key)
                .ToListAsync();
            return medicines;
        }
    }
}
