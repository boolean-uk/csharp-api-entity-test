namespace workshop.wwwapi.Models.DTOs
{
    public class DoctorAppointmentDTO
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
