using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class DoctorAppointmentDTO
    {
        public DateTime Booking { get; set; }
        public PatientDTOWithoutAppointments? Patient { get; set; }
    }
}
