namespace workshop.wwwapi.Models.DTOs
{
    public class AppointmentResponseDTO
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime Booking { get; set; }
    }
}
