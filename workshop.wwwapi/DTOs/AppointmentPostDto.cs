namespace workshop.wwwapi.DTOs
{
    public class AppointmentPostDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Booking { get; set; } 

    }
}
