using blood_donation_backend.BLL.Interfaces;
using blood_donation_backend.blood_donation_backend.BLL.Models;
using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Entities;

namespace blood_donation_backend.Services
{
    public class PatientService : IPatientService

    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task Create(PatientModel patient)
        {
            patient.Id = new Guid();
            var newPatient = new Patient
            {
                PatientId = (Guid)patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Age = patient.Age,
                BloodType = patient.BloodType,
                Gender = patient.Gender,
                PhoneNumber = patient.PhoneNumber,
                CurrentDonorId = patient.DonorId
            };

            await _patientRepository.Create(newPatient);

        }

        public async Task<List<PatientModel>> GetAll()
        {
            var patientsDb = await _patientRepository.GetAll();
            var list = new List<PatientModel>();
            foreach (var patient in patientsDb)
            {
                var parientModel = new PatientModel
                {
                    Id = patient.PatientId,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Age = patient.Age,
                    Gender = patient.Gender,
                    BloodType = patient.BloodType

                };
                list.Add(parientModel);

            }

              return list;
        }


       
        public async Task<PatientModel> GetById(Guid id)
        {
            var patient = await (_patientRepository.GetById(id));
            if (patient == null)
            { 
                return null;
            }
            var patientModel = new PatientModel
             {
                    Id = patient.PatientId,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Age = patient.Age,
                    Gender = patient.Gender,
                    BloodType = patient.BloodType

             };
            return patientModel;
        }
        public async Task<bool> UpdateById(Guid id, PatientModel patient)
        {
            var patientDb = await _patientRepository.GetById(id);
            if (patientDb != null)
            {
                patientDb.PatientId = id;
                patientDb.FirstName = patient.FirstName;
                patientDb.LastName = patient.LastName;
                patientDb.Age = patient.Age;
                patientDb.Gender = patient.Gender;
                patientDb.BloodType = patient.BloodType;
                return true;
            }
            else return false;



        }
        public async Task<List<MedicineModel>> GetMedicinesByPatientId(Guid patientId)
        {
            var medicines = await _patientRepository.GetMedicinesByPatientId(patientId);
            var list = new List<MedicineModel>();
            foreach(var medicine in medicines)
            {
                var medicineModel = new MedicineModel
                {
                    Id = medicine.MedicineId,
                    Name = medicine.Name,
                    ExpirationDate = medicine.ExpirationDate,
                    Prospect = medicine.Prospect,
                };
                list.Add(medicineModel);
            }
            return list;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var patientDb = await _patientRepository.GetById(id);
            if (patientDb != null)
            {
                await _patientRepository.DeletePatient(patientDb);
                return true;
            }
            else return false;

        }
  

    }
}
