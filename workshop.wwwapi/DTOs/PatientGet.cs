using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class PatientGet
    {
        public string FullName { get; set; }
        public ICollection<PatientAppointmentGet> Appointments { get; set; } = new List<PatientAppointmentGet>();
    }
}
