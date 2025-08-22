namespace workshop.wwwapi.DTOs
{
    public class PatientDTO
    {
        public string FullName { get; set; }
        public List<AppointmentDTO> Appointments { get; set; } = new();
    }
}
