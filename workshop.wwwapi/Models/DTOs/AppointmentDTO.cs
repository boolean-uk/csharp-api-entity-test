namespace workshop.wwwapi.Models.DTOs
{
    public class AppointmentDTO
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime BookingTime { get; set; }
        public AppointmentType AppointmentType { get; set; }
    }
}
