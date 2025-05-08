namespace workshop.wwwapi.Models.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<AppointmentDTO> Appointments { get; set; } = new List<AppointmentDTO>();
    }
}
