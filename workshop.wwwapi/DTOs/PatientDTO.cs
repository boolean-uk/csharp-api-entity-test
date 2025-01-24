namespace workshop.wwwapi.DTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<PatientAppointmentDTO> Appointments { get; set; }
    }
}
