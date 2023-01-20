using blood_donation_backend.blood_donation_backend.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace blood_donation_backend.Entities
{
    public class Donor 
    {
        public Guid DonorId { get; set; }
        [StringLength(70)]
        public string? FirstName { get; set; }

        [StringLength(70)]
        public string? LastName { get; set; }

        [Range(0, 100)]
        public int Age { get; set; }
        public string? BloodType { get; set; }

        public string? Gender { get; set; }

        //patientii carora le a donat 
        //one to many
        public ICollection<Patient>? Patients { get; set; }

       
        public Test? Test { get; set; }
        public virtual string UserId { get; set; }
        public virtual AppUser User { get; set; }

    }
}
