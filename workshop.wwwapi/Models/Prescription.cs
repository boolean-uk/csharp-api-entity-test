namespace workshop.wwwapi.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public List<MedicinePrescription> Medicines { get; set; } = new();
    }
}
