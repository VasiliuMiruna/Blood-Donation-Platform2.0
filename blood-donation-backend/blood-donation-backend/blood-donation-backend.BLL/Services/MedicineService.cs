using blood_donation_backend.blood_donation_backend.BLL.Interfaces;
using blood_donation_backend.blood_donation_backend.BLL.Models;
using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Entities;

namespace blood_donation_backend.blood_donation_backend.BLL.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public async Task Create(MedicineModel medicine)
        {
            medicine.Id = new Guid();
            var newMedicine = new Medicine
            {
                MedicineId = (Guid)medicine.Id,
                Name = medicine.Name,
                ExpirationDate = medicine.ExpirationDate,
                Prospect = medicine.Prospect,
            };

            await _medicineRepository.Create(newMedicine);

        }
        public async Task<List<MedicineModel>> GetAll()
        {
            var medicineDb = await _medicineRepository.GetAll();
            var list = new List<MedicineModel>();
            foreach (var medicine in medicineDb)
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
    }
}
