using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentDTO
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
