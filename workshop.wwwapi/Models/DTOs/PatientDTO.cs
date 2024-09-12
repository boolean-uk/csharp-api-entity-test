namespace workshop.wwwapi.Models.DTOs
{
    public class PatientDTO
    {
        public string FullName { get; set; }

        public List<AppointmentPatientDTO> Appointments { get; set; } = new List<AppointmentPatientDTO>();
    }
}
