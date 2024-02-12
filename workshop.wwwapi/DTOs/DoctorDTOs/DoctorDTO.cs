using workshop.wwwapi.DTOs.AppointmentDTOs;

namespace workshop.wwwapi.DTOs.DoctorDTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<AppointmentPatientDTO> Appointments { get; set; } = new List<AppointmentPatientDTO>();
    }
}
