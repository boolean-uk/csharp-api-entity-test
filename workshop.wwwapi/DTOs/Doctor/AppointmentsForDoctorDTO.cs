using workshop.wwwapi.DTOs.Patient;
using workshop.wwwapi.DTOs.Person;

namespace workshop.wwwapi.DTOs.Doctor
{
    public class AppointmentsForDoctorDTO
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }

        public NestedPersonForAppointmentDTO Patient { get; set; }
    }
}
