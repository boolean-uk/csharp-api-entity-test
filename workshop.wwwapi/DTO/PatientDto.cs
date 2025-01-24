using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientDto
    {
        public string FullName { get; set; }
        public List<PatientAppointmentDto> Appointments { get; set; } = new List<PatientAppointmentDto>();
    }
}
