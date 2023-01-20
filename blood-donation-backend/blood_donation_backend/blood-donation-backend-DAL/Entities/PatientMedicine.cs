
using System.ComponentModel.DataAnnotations.Schema;

namespace blood_donation_backend.Entities
{

    public class PatientMedicine 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid? PatientMedicineId { get; set; }
        public Guid? PatientId { get; set; }
        public Patient? Patient { get; set; }
        public Guid? MedicineId { get; set; }
        public Medicine? Medicine { get; set; }
    }
}
