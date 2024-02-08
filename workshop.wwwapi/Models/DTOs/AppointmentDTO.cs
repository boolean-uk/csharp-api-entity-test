namespace workshop.wwwapi.Models.DTOs
{
    public class AppointmentDTO
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public string DoctorFullName { get; set; }
        public int PatientId { get; set; }
        public string PatientFullName { get; set; }
    }
    public class DoctorAppointmentDTO
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public string DoctorFullName { get; set; }
    }

    public class PatientAppointmentDTO
    {
        public DateTime Booking { get; set; }
        public int PatientId { get; set; }
        public string PatientFullName { get; set; }
    }
}
