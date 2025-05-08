namespace workshop.wwwapi.Models
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public IEnumerable<PatientAppointmentDto> Appointments { get; set; }
    }
}
