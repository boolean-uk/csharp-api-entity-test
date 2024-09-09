using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientAppointments
    {
        public string Type { get; set; }
        public DateTime Booking { get; set; }
        public DoctorInfo Doctor { get; set; }
    }
}
