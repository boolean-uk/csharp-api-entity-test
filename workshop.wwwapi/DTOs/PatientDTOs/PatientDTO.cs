using workshop.wwwapi.DTOs.AppointmentDTOs;

namespace workshop.wwwapi.DTOs.PatientDTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<AppointmentDoctorDTO> Appointments { get; set; } = new List<AppointmentDoctorDTO>();

    }
}
