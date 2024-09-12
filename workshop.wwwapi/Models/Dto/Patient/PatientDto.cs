using workshop.wwwapi.Models.Dto.Appointment;

namespace workshop.wwwapi.Models.Dto.Patient
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AppointmentDoctorDto> Appointments { get; set; } = new List<AppointmentDoctorDto>();
    }
}
