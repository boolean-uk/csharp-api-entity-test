using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientListDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<AppointmentPatientListDTO> Appointments { get; set; } = new List<AppointmentPatientListDTO>();
    }
}
