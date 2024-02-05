namespace workshop.wwwapi.Models.DTOs
{
    public class PatientDTO
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public ICollection<PatientAppointmentDTO> Appointments { get; set; }

    }
}
