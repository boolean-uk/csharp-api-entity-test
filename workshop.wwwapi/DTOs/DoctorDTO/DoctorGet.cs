using workshop.wwwapi.DTOs.PatientDTO;

namespace workshop.wwwapi.DTOs.DoctorDTO
{
    public class DoctorGet
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<DoctorAppointmentGet> Appointments { get; set; } = new List<DoctorAppointmentGet>();
    }
}
