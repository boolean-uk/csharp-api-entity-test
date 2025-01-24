namespace workshop.wwwapi.DTO
{
    public class DoctorDto
    {
        public string FullName { get; set; }
        public List<DoctorAppointmentDto> Appointments { get; set; } = new List<DoctorAppointmentDto>();
    }
}
