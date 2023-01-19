using blood_donation_backend.blood_donation_backend.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace blood_donation_backend.blood_donation_backend.BLL.Models
{
    public class PatientModel
    {
        public Guid Id { get; set; }

        [StringLength(70)]
        public string? FirstName { get; set; }

        [StringLength(70)]
        public string? LastName { get; set; }

        [Range(0, 100)]
        public int Age { get; set; }
        public string? BloodType { get; set; }

        public string? Gender { get; set; }

        public string? PhoneNumber { get; set; }

        public Guid? DonorId { get; set; }

        
        public IList<MedicineModel>? Medicines { get; set; }

/*        public int UserId { get; set; }
        public virtual AppUser User { get; set; }*/



    }
}
