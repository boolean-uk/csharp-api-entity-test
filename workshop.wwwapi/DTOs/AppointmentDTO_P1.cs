using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class AppointmentDTO_P1
    {
        public DoctorDTO_L1 Doctor { get; set; }
        public DateTime Booking { get; set; }
    }
}
