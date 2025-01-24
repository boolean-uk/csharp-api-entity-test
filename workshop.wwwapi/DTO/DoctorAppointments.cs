using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class DoctorAppointments
    {
        public string Type { get; set; }
        public DateTime Booking { get; set; }
        public PatientInfo Patient { get; set; }
    }
}
