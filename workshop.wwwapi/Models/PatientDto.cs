namespace workshop.wwwapi.Models
{
    public class PatientDto
    {
        public string? FullName { get; set; }
        public List<AppointmentDto> Appointments { get; set; }
    }
}
