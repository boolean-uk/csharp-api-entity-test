
namespace workshop.wwwapi.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public ICollection<PrescribedMedicine> Medicines { get; set; } = new List<PrescribedMedicine>();
        public Appointment Appointment { get; set; }
    }
}
