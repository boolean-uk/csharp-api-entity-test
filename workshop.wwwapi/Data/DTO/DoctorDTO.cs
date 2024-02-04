using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data.DTO
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public List<AppointmentDoctorDTO> Appointments { get; set; } = new List<AppointmentDoctorDTO>();
    }
}
