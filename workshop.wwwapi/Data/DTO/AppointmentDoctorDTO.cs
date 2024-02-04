using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data.DTO
{
    public class AppointmentDoctorDTO
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime Booking { get; set; }
        public string AppointmentType { get; set; }

    }
}
