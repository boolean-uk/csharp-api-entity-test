using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs.Core
{
    public class DoctorDTO_L2
    {
        public string FullName { get; set; }
        public ICollection<AppointmentDTO_D1> Appointments { get; set; } = new List<AppointmentDTO_D1>();
    }
}
