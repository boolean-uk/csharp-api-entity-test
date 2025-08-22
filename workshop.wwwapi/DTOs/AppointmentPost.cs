namespace workshop.wwwapi.DTOs
{
    public class AppointmentPost
    {
        public DateTime Booking { get; set; } = DateTime.UtcNow;
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
