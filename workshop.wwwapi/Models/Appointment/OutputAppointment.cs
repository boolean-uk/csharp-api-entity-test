namespace workshop.wwwapi.Models
{
    public class OutputAppointment
    {
        public int Id { get; set; }
        public DateTime Booking { get; set; }
        public DoctorWhithoutAppointment Doctor { get; set; }
        public PatientWhithoutAppointment Patient { get; set; }
        public PrescriptionWhitoutAppointment? Prescription { get; set; }
        public string Type { get; set; }
    }
}