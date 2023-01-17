namespace blood_donation_backend.blood_donation_backend.BLL.Models
{
    public class MedicineModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? Prospect { get; set; }
        public List<PatientModel> Patients { get; set; }
    }
}
