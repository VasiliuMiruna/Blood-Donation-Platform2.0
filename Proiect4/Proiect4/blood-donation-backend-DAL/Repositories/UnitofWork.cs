using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Data;

namespace blood_donation_backend.blood_donation_backend.DAL.Repositories
{
    public class UnitofWork 
    {
        protected readonly AppDbContext _context;

        public UnitofWork(AppDbContext context)
        {
            /*_context = context;
            Donors = new DonorRepository(context);
            Patients = new PatientRepository(context);*/
            /*Medicines = new MedicineRepository(context);
            Addresses = new AddressRepository(context);
            Doctors = new DoctorRepository(context);*/
        }

       /* public IDonorRepository Donors { get; private set; }
        public IPatientRepository Patients { get; private set; }
        public IMedicineRepository Medicines { get; private set; }
        public IDoctorRepository Doctors { get; private set; }


        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    */
}
}
