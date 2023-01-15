

namespace blood_donation_backend.Entities
{
    public class Medicine 
    {
        public Guid MedicineId { get; set; }
        public string? Name { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? Prospect { get; set; }

        public IList<PatientMedicine>? PatientMedicines { get; set; }
    }
}
