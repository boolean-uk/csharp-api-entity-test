namespace workshop.wwwapi.Models.DTO
{
    public class PatientDTO
    {
        public string FullName { get; set; }

        // Navigation property for appointments
        public List<AppointmentForPatientDTO> Appointments { get; set; } = new List<AppointmentForPatientDTO>();
    }
    public class PatientNameDTO
    {
        public string FullName { get; set; }
    }
}
