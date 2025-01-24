using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientAppointmentsDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public ICollection<GetAppointmentDTO> Appointments { get; set; } = new List<GetAppointmentDTO>();
    }
}
