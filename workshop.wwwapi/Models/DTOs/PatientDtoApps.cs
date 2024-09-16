namespace workshop.wwwapi.Models.DTOs
{
    public class PatientDtoApps
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<AppointmentForPatientDto> Appointments { get; set; } = new List<AppointmentForPatientDto>();
    }
}
