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

        /*public Patient GetPatientById(Guid Id)
        {
            var patient = _patientRepository
                .
        }*/

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
                PhoneNumber = patient.PhoneNumber
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
        public async Task UpdateById(PatientModel patient)
        {
            //var patient = _patientRepository.GetById(id);
            var patientdb = new Patient
            {
                PatientId = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Age = patient.Age,
                BloodType = patient.BloodType,
                Gender = patient.Gender
            };
            await _patientRepository.UpdatePatient(patientdb);
            


        }
        public async Task DeleteById(Guid id)
        {
            //var patient = await _patientRepository.GetById(id);
            //await _patientRepository.DeletePatient(Guid id);

        }
        /* public void Update(PatientModel patient)
         {
             var newPatient =
         }*/



        /* public void Delete(PatientModel patient)
         {
             throw new NotImplementedException();
         }
 */

        /* public async Task<List<string>> ModifyPatient()
{
//la o lista de donatori afisam 
var patients = await _patientRepo.GetAll();
var list = new List<string>();

foreach (var patient in patients)
{
list.Add($" Patient First Name: {patient.FirstName}," +
$"Patient Last Name: {patient.LastName}," +
$"Patient Blood Type: {patient.BloodType}," +
$"Patient Age: {patient.Age}," +
$"Patient Gender: {patient.Gender}");
}

return list;
}*/

    }
}
