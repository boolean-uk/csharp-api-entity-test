namespace workshop.wwwapi.DTOs
{
    public class DoctorDto
    {
        public string FullName { get; set; }
        public ICollection<AppointmentForDoctorDto> Appointments { get; set; } = new List<AppointmentForDoctorDto>();
    }
}
