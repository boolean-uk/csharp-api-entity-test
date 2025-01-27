namespace workshop.wwwapi.DTOs
{
    public class AppointmentDTO
    {
        public DateTime Booking { get; set; }
        public string PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
