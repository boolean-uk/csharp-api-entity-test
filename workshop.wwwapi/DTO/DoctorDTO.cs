using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<DoctorAppointmentDTO> Appointments { get; set; } //holds name, id, name, id

        public DoctorDTO(int id, string name)
        {
            FullName = name;
            Id = id;
            Appointments = new List<DoctorAppointmentDTO>(); // initialize list in constructor
        }
    }
}
