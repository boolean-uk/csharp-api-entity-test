using workshop.wwwapi.Models.Dto.Appointment;

namespace workshop.wwwapi.Models.Dto.Doctor
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AppointmentPatientDto> Appointments { get; set; } = new List<AppointmentPatientDto>();
    }
}
