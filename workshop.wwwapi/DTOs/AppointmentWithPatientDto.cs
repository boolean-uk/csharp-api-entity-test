namespace workshop.wwwapi.DTOs
{
    public class AppointmentWithPatientDto
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;

        public DateTime Booking { get; set; } 
    }
}