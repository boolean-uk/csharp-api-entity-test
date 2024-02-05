namespace workshop.wwwapi.Models
{
    public class AppointmentPost
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime Booking { get; set; }
    }
}
