using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentDTO
    {
        public DateTime Booking { get; set; }
        public DoctorInfo Doctor { get; set; }
        public PatientInfo Patient { get; set; }
    }
}
