using blood_donation_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace blood_donation_backend.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<PatientMedicine> PatientMedicines { get; set; }
        public DbSet<PatientDoctor> PatientDoctor { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            //one to many between Donor - Patient
            modelBuilder.Entity<Patient>()
                .HasOne<Donor>(p => p.Donor)
                .WithMany(d => d.Patients)
                .HasForeignKey(p => p.CurrentDonorId);

            //one to many between Doctor - Test (A doctor can run multiple tests)
            modelBuilder.Entity<Test>()
                .HasOne<Doctor>(t => t.Doctor)
                .WithMany(d => d.Tests)
                .HasForeignKey(t => t.DoctorId);

            //one to one between Patient and Test
            modelBuilder.Entity<Patient>()
                .HasOne<Test>(p => p.Test)
                .WithOne(t => t.Patient)
                .HasForeignKey<Test>(t => t.PatientId);


            //one to one between Donor and Test
            modelBuilder.Entity<Donor>()
                .HasOne<Test>(d => d.Test)
                .WithOne(t => t.Donor)
                .HasForeignKey<Test>(t => t.DonorId);


            //many to many between Patient and Medicine
            //=> one patient may take multiple medicines
            //=> one medicine may be administrated to multiple patients

            //firstly, we define the composite key 
            modelBuilder.Entity<PatientMedicine>().HasKey(pm => new { pm.PatientId, pm.MedicineId });

            modelBuilder.Entity<PatientMedicine>()
                .HasOne<Patient>(pm => pm.Patient)
                .WithMany(p => p.PatientMedicines)
                .HasForeignKey(pm => pm.PatientId);


            modelBuilder.Entity<PatientMedicine>()
                .HasOne<Medicine>(pm => pm.Medicine)
                .WithMany(p => p.PatientMedicines)
                .HasForeignKey(pm => pm.MedicineId);



            //many to many between Patient and Doctor
            //=> one patient can have multiple doctors 
            //=> one doctor can have multiple patients

            //firstly, we define the composite key 
            modelBuilder.Entity<PatientDoctor>().HasKey(pm => new { pm.PatientId, pm.DoctorId });

            modelBuilder.Entity<PatientDoctor>()
                .HasOne<Patient>(pm => pm.Patient)
                .WithMany(p => p.PatientDoctors)
                .HasForeignKey(pm => pm.PatientId);


            modelBuilder.Entity<PatientDoctor>()
                .HasOne<Doctor>(pm => pm.Doctor)
                .WithMany(p => p.PatientDoctors)
                .HasForeignKey(pm => pm.DoctorId);



        }
    }
}
