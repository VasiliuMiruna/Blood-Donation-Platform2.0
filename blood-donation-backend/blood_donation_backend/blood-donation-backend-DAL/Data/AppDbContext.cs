using blood_donation_backend.blood_donation_backend.DAL.Entities;
using blood_donation_backend.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace blood_donation_backend.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>

    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<PatientMedicine> PatientMedicines { get; set; }
        public DbSet<PatientDoctor> PatientDoctors { get; set; }
        public DbSet<AppUserRefreshToken> RefreshTokens { get; set; }

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
                .HasForeignKey(p => p.CurrentDonorId)
                .OnDelete(DeleteBehavior.Cascade); 

            //one to many between Doctor - Test (A doctor can run multiple tests)
            modelBuilder.Entity<Test>()
                .HasOne<Doctor>(t => t.Doctor)
                .WithMany(d => d.Tests)
                .HasForeignKey(t => t.DoctorId)
                .OnDelete(DeleteBehavior.Cascade); 

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

            

            modelBuilder.Entity<Donor>()
                    .HasOne(d => d.User)
                    .WithOne(au => au.Donor)
                    .HasForeignKey<Donor>(d => d.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Admin>()
                    .HasOne(d => d.User)
                    .WithOne(au => au.Admin)
                    .HasForeignKey<Admin>(d => d.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Doctor>()
                    .HasOne(d => d.User)
                    .WithOne(au => au.Doctor)
                    .HasForeignKey<Doctor>(d => d.UserId)
                    .OnDelete(DeleteBehavior.NoAction); 
            modelBuilder.Entity<Patient>()
                    .HasOne(d => d.User)
                    .WithOne(au => au.Patient)
                    .HasForeignKey<Patient>(d => d.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AppUserRefreshToken>()
                    .HasOne(d => d.User)
                    .WithMany(au => au.RefreshTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade); 


            //many to many between Patient and Medicine
            //=> one patient may take multiple medicines
            //=> one medicine may be administrated to multiple patients

            //firstly, we define the composite key 
            modelBuilder.Entity<PatientMedicine>().HasKey(pm => new { pm.PatientId, pm.MedicineId });

            modelBuilder.Entity<PatientMedicine>()
                .HasOne<Patient>(pm => pm.Patient)
                .WithMany(p => p.PatientMedicines)
                .HasForeignKey(pm => pm.PatientId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<PatientMedicine>()
                .HasOne<Medicine>(pm => pm.Medicine)
                .WithMany(p => p.PatientMedicines)
                .HasForeignKey(pm => pm.MedicineId)
                .OnDelete(DeleteBehavior.Cascade);



            //many to many between Patient and Doctor
            //=> one patient can have multiple doctors 
            //=> one doctor can have multiple patients

            //firstly, we define the composite key 
            modelBuilder.Entity<PatientDoctor>().HasKey(pm => new { pm.PatientId, pm.DoctorId });

            modelBuilder.Entity<PatientDoctor>()
                .HasOne<Patient>(pm => pm.Patient)
                .WithMany(p => p.PatientDoctors)
                .HasForeignKey(pm => pm.PatientId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<PatientDoctor>()
                .HasOne<Doctor>(pm => pm.Doctor)
                .WithMany(p => p.PatientDoctors)
                .HasForeignKey(pm => pm.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
