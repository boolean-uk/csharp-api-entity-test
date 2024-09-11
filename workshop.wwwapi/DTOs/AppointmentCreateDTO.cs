namespace workshop.wwwapi.DTOs
{
    public class AppointmentCreateDTO
    {
        public DateTime AppointmentDate { get; set; }
        public int doctorId { get; set; }
        public int patientId { get; set; }
    }
}
