namespace workshop.wwwapi.Models
{
    public class DoctorDto
    {
        public string? FullName { get; set; }
        public List<AppointmentDto> Appointments { get; set; }
    }

}
