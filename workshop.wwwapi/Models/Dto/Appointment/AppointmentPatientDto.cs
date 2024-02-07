using workshop.wwwapi.Models.Dto.Doctor;
using workshop.wwwapi.Models.Dto.Patient;

namespace workshop.wwwapi.Models.Dto.Appointment
{
    public class AppointmentPatientDto
    {
        public DateTimeOffset Booking { get; set; }
        public int PatientId { get; set; }
        public PatientPlainDto Patient { get; set; }
    }
}
