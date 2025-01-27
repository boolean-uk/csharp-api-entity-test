namespace workshop.wwwapi.DTO
{
    public class PatientDTO
    {
        public string fullName { get; set; }
        public List<AppointmentDTO> Appointments { get; set; }
    }
}
