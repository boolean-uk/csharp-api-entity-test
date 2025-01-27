using workshop.wwwapi.DTOs;

namespace workshop.wwwapi.DTOs
{
    public class PatientDTO()
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<AppointmentDTO2> Appointments { get; set; } = new List<AppointmentDTO2>();
    }
}

