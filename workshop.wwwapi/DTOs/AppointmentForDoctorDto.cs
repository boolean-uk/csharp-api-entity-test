using workshop.wwwapi.enums;

namespace workshop.wwwapi.DTOs
{
    public class AppointmentForDoctorDto
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }

        public DateTime Booking { get; set; }
        public AppointmentTypeEnum Type { get; set; }
    }
}
