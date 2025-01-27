namespace workshop.wwwapi.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public string Notes { get; set; }

        public List<Medicine> Medicines { get; set; } = [];
        public List<MedicinePrescription> MedicinePrescriptions { get; set; } = [];

        public int AppointmentDoctorId { get; set; }
        public int AppointmentPatientId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
