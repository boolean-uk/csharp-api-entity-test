namespace workshop.wwwapi.Models.DTOs
{
    public class AppointmentDoctorDTO
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime Booking { get; set; }
    }
}
