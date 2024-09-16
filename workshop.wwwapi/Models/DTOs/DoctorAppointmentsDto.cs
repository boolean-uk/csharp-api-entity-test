namespace workshop.wwwapi.Models.DTOs
{
    public class DoctorAppointmentsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<AppointmentForDoctorDto> Appointments { get; set; } = new List<AppointmentForDoctorDto>();
    }
}
