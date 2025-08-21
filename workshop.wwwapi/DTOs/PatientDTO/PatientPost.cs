using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs.PatientDTO
{
    public class PatientPost
    {
        public string FullName { get; set; }
        //public ICollection<AppointmentPost> Appointments { get; set; } = new List<AppointmentPost>();
    }
}
