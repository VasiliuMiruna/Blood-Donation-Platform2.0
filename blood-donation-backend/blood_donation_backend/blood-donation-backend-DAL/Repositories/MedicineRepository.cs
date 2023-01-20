using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Data;
using blood_donation_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace blood_donation_backend.blood_donation_backend.DAL.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly AppDbContext _db;

        public MedicineRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task Create(Medicine medicine)
        {
            await _db.Medicines.AddAsync(medicine);
            await _db.SaveChangesAsync();
        }
        public async Task<List<Medicine>> GetAll()
        {
            var medicines = _db.Medicines;
            var list = new List<Medicine>();
            foreach (var medicine in medicines)
            {
                var medicineModel = new Medicine
                {
                   
                   MedicineId = medicine.MedicineId,
                   Name = medicine.Name,
                   ExpirationDate = medicine.ExpirationDate,
                   Prospect =  medicine.Prospect

                };
                list.Add(medicineModel);
            }
            return list;
        }
        public async Task<Medicine> GetById(Guid id)
        {
            return _db.Medicines.FirstOrDefault(p => p.MedicineId == id);


        }

        public async Task DeleteMedicine(Medicine medicine)
        {
            _db.Medicines.Remove(medicine);
            await _db.SaveChangesAsync();

        }

    }
}
