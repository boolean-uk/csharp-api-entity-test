namespace workshop.wwwapi.Models
{
    public class Prescription
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = null!;

        public List<Medicine> Medicines { get; } = [];
    }
}