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
        public async Task<MedicineModel> GetById(Guid id)
        {
            var medicine = await (_medicineRepository.GetById(id));
            if (medicine == null)
            {
                return null;
            }
            var medicineModel = new MedicineModel
            {
                Id = medicine.MedicineId,
                Prospect = medicine.Prospect,
                Name = medicine.Name,
                ExpirationDate=medicine.ExpirationDate,

            };
            return medicineModel;
        }
        public async Task<bool> DeleteById(Guid id)
        {
            var medicineDb = await _medicineRepository.GetById(id);
            if (medicineDb != null)
            {
                await _medicineRepository.DeleteMedicine(medicineDb);
                return true;
            }
            else return false;

        }
    }
}
