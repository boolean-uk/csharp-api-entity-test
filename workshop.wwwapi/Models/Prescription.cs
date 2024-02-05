namespace workshop.wwwapi.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int AppointmentDoctorId { get; set; }
        public int AppointmentPatientId { get; set; }
        public List<PrescriptionMedicine> PrescriptionMedicines { get; set; } = [];
        public int Quantity { get; set; }
    }
}
