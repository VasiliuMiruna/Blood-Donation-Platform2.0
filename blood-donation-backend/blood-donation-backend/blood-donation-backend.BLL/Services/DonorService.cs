using blood_donation_backend.blood_donation_backend.BLL.Interfaces;
using blood_donation_backend.blood_donation_backend.BLL.Models;
using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Entities;

namespace blood_donation_backend.blood_donation_backend.BLL.Services
{
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _donorRepository;

        public DonorService(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task Create(DonorModel donor)
        {
            donor.Id = new Guid();
            var newDonor = new Donor
            {
                DonorId = (Guid)donor.Id,
                FirstName = donor.FirstName,
                LastName = donor.LastName,
                Age = donor.Age,
                Gender = donor.Gender,
                BloodType = donor.BloodType,
            };

            await _donorRepository.Create(newDonor);

        }

        public async Task<List<DonorModel>> GetAll()
        {
            var donorDb = await _donorRepository.GetAll();
            var list = new List<DonorModel>();
            foreach (var donor in donorDb)
            {
                var donorModel = new DonorModel
                {
                    Id = donor.DonorId,
                    FirstName = donor.FirstName,
                    LastName = donor.LastName,
                    Age = donor.Age,
                    Gender = donor.Gender,
                    BloodType = donor.BloodType,

                };
                list.Add(donorModel);

            }

            return list;
        }

        public async Task<DonorModel> GetById(Guid id)
        {
            var donor = await (_donorRepository.GetById(id));
            var donorModel = new DonorModel
            {
                Id = donor.DonorId,
                FirstName = donor.FirstName,
                LastName = donor.LastName,
                Age = donor.Age,
                Gender = donor.Gender,
                BloodType = donor.BloodType

            };
            return donorModel;
        }
        public async Task UpdateById(DonorModel donor)
        {
            //var patient = _patientRepository.GetById(id);
            var donordb = new Donor
            {
                DonorId = donor.Id,
                FirstName = donor.FirstName,
                LastName = donor.LastName,
                Age = donor.Age,
                Gender = donor.Gender,
                BloodType = donor.BloodType
            };
            await _donorRepository.UpdateDonor(donordb);



        }

        public async Task<List<PatientModel>> GetPatientsOfDonors(Guid donorId)
        {
            var patients = await _donorRepository.GetPatientsOfDonors(donorId);
            var list = new List<PatientModel>();
            foreach (var patient in patients)
            {
                var patientModel = new PatientModel
                {
                    Id = patient.PatientId,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Age = patient.Age,
                    BloodType = patient.BloodType,
                    Gender = patient.Gender,
                };
                list.Add(patientModel);
            }
            return list;

        }
        public async Task<List<DonorModel>> GetDonorsByBloodType(string bloodType)
        {
            var donors = await _donorRepository.GetDonorsByBloodType(bloodType);
            var list = new List<DonorModel>();
            foreach (var donor in donors)
            {
                var donorModel = new DonorModel
                {
                    Id = donor.DonorId,
                    FirstName = donor.FirstName,
                    LastName = donor.LastName,
                    Age = donor.Age,
                    BloodType = donor.BloodType,
                    Gender = donor.Gender
                };
                list.Add(donorModel);
                 
            }
            return list;
        }
    }
}
