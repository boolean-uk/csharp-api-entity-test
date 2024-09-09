using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentView
    {
        public AppointmentType Type { get; set; }
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
