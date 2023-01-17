using blood_donation_backend.blood_donation_backend.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace blood_donation_backend.Entities
{
    public class Patient
    { 
        
        public Guid PatientId { get; set; }
        [StringLength(70)]
        public string? FirstName { get; set; }

        [StringLength(70)]
        public string? LastName { get; set; }

        [Range(0, 100)]
        public int Age { get; set; }
        public string? BloodType { get; set; }

        public string? Gender { get; set; }

        public string? PhoneNumber { get; set; }

        public Guid? CurrentDonorId { get; set; }
        public Donor? Donor { get; set; }


        public Test? Test { get; set; }

        public IList<PatientMedicine>? PatientMedicines { get; set; }
        public IList<PatientDoctor>? PatientDoctors { get; set; }

        /*public Guid UserId { get; set; }
        public virtual AppUser User { get; set; }*/



    }

}

