using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class PatientDTO
    {
        public string Fullname { get; set; }
        public List<AppointmentForPatientDTO> Appointments { get; set; } = new List<AppointmentForPatientDTO>();
    }
}
