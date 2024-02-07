using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs.Core
{
    public class AppointmentDTO_P1
    {
        public DoctorDTO_L1 Doctor { get; set; }
        public string AppointmentType { get; set; }
        public DateTime Booking { get; set; }
    }
}
