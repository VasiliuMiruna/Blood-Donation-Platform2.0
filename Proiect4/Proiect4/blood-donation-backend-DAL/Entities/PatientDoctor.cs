

using System.ComponentModel.DataAnnotations.Schema;

namespace blood_donation_backend.Entities
{
    public class PatientDoctor 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PatientDoctorId { get; set; }
        public Guid? PatientId { get; set; }
        public Patient? Patient { get; set; }
        public Guid? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

       
    }
}
