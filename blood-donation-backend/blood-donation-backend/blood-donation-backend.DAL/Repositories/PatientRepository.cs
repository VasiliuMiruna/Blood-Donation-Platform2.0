using blood_donation_backend.blood_donation_backend.DAL.Helpers;
using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Data;
using blood_donation_backend.Entities;
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
            var patients = _db.Patients;
            var list = new List<Patient>();
            foreach (var patient in patients)
            {
                var patientModel = new Patient
                {
                    PatientId = patient.PatientId,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Age = patient.Age,
                    BloodType = patient.BloodType,
                    Gender = patient.Gender,
                    PhoneNumber = patient.PhoneNumber

                };
                list.Add(patientModel); 
            }
            return list;
        }

        public async Task<Patient> GetById(Guid id)
        {
            var patient = _db.Patients.FirstOrDefault(p => p.PatientId == id);
            /* var patients = _db.Patients.WhereClauses(id);
             var patientdb = new Patient();
             foreach (var patient in patients)
             {
                 patientdb.PatientId = patient.PatientId;
                 patientdb.FirstName = patient.FirstName;
                 patientdb.LastName = patient.LastName;
                 patientdb.PhoneNumber = patient.PhoneNumber;
                 patientdb.Age = patient.Age;
                 patientdb.Gender = patient.Gender;
             }
             return patientdb;*/
            return patient;

        }
        /*   public void Delete(Patient patient)
           {
               db.Patients.Remove(patient);
               db.SaveChanges();
           }

           public void Update(Patient patient)
           {
               db.Patients.Update(patient);
               db.SaveChanges();
           }*/

        public async Task UpdatePatient(Patient patient)
        {
            var newPatient = _db.Patients.Find(patient.PatientId);
            if (newPatient != null)
            {
                newPatient.FirstName = patient.FirstName;
                newPatient.LastName = patient.LastName;
                newPatient.Age = patient.Age;
                newPatient.Gender = patient.Gender;
                newPatient.PhoneNumber = patient.PhoneNumber;
                newPatient.BloodType = patient.BloodType;

                _db.SaveChangesAsync();
            };
        }

        public async Task DeletePatient(Guid id)
        {
            // Query the database for the rows to be deleted.
           /* var deleteOrderDetails =
                from details in db.OrderDetails
                where details.OrderID == 11000
                select details;

            foreach (var detail in deleteOrderDetails)
            {
                db.OrderDetails.DeleteOnSubmit(detail);
            }

            try
            {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }*/

          /*  var deletePatient = 
                from patient in _db
                where patient.PatientId == id
                select patient;

            foreach (var patient in deletePatient)
            {
               
            }
            _db.Remove(patient);
            _db.SaveChanges();
*/
        }
    }
}
