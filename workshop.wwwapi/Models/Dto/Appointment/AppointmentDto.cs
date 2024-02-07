using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.Dto.Doctor;
using workshop.wwwapi.Models.Dto.Patient;

namespace workshop.wwwapi.Models.Dto.Appointment
{
    public class AppointmentDto
    {
        public DateTimeOffset Booking { get; set; }
        public int DoctorId { get; set; }
        public DoctorPlainDto Doctor { get; set; }
        public int PatientId { get; set; }
        public PatientPlainDto Patient { get; set; }
    }
}
