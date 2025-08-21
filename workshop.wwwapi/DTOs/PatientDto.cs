namespace workshop.wwwapi.DTOs
{
    public class PatientDto
    {
        public string FullName { get; set; }
        public ICollection<AppointmentForPatientDto> Appointments { get; set; } = new List<AppointmentForPatientDto>();
    }
}
