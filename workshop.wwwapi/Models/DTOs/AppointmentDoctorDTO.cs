using workshop.wwwapi.Enums;

namespace workshop.wwwapi.Models.DTOs
{
    public class AppointmentDoctorDTO
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime Booking { get; set; }
        public string AppointmentType { get; set; }
    }
}
