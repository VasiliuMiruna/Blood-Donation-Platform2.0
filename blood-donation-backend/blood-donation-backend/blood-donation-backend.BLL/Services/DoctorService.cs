using blood_donation_backend.blood_donation_backend.BLL.Interfaces;
using blood_donation_backend.blood_donation_backend.BLL.Models;
using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Entities;

namespace blood_donation_backend.blood_donation_backend.BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task Create(DoctorModel doctor)
        {
            doctor.Id = new Guid();
            var newDoctor = new Doctor
            {
                DoctorId = (Guid)doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Age = doctor.Age,
                Salary = doctor.Salary
            };

            await _doctorRepository.Create(newDoctor);

        }

        public async Task<List<DoctorModel>> GetAll()
        {
            var doctorDb = await _doctorRepository.GetAll();
            var list = new List<DoctorModel>();
            foreach (var doctor in doctorDb)
            {
                var doctorModel = new DoctorModel
                {
                    Id = doctor.DoctorId,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Age = doctor.Age,
                    Salary = doctor.Salary

                };
                list.Add(doctorModel);

            }

            return list;
        }

        public async Task<DoctorModel> GetById(Guid id)
        {
            var doctor = await (_doctorRepository.GetById(id));
            var doctorModel = new DoctorModel
            {
                Id = doctor.DoctorId,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Age = doctor.Age,
                Salary = doctor.Salary

            };
            return doctorModel;
        }
        public async Task UpdateById(DoctorModel doctor)
        {
            //var patient = _patientRepository.GetById(id);
            //dau getbyid aici vf daca exista daca nu arunc eroare
            var doctordb = new Doctor
            {
                DoctorId = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Age = doctor.Age,
                Salary = doctor.Salary
            };
            await _doctorRepository.UpdateDoctor(doctordb);



        }
    }
}
