using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientAppointmentDTO
    {
        public DateTime Booking { get; set; }
        public DoctorDTOWithoutAppointments? Doctor { get; set; }
    }
}
