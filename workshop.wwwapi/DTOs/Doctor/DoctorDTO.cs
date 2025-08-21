using workshop.wwwapi.DTOs.Patient;

namespace workshop.wwwapi.DTOs.Doctor
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<AppointmentsForDoctorDTO> Appointments { get; set; }
    }
}
