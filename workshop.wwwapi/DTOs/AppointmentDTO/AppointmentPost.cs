namespace workshop.wwwapi.DTOs.AppointmentDTO
{
    public class AppointmentPost
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
