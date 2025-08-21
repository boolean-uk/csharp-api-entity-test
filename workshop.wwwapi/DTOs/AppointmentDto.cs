using workshop.wwwapi.enums;

namespace workshop.wwwapi.DTOs
{
    public class AppointmentDto
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime Booking { get; set; }
        public AppointmentTypeEnum Type { get; set; }
    }
}
