using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs.Core
{
    public class AppointmentDTO_D1
    {
        public PatientDTO_L1 Patient { get; set; }
        public string AppointmentType { get; set; }
        public DateTime Booking { get; set; }
    }
}
