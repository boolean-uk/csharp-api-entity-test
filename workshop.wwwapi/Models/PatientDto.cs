namespace workshop.wwwapi.Models
{
    public class PatientDto
    {
        public int Id {  get; set; }
        public string FullName { get; set; }
        public IEnumerable<DoctorAppointmentDto> Appointments { get; set; }
    }
}
