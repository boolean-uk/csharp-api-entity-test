namespace workshop.wwwapi.DTOs
{
    public class CreateAppointmentDTO
    {

        public int doctorId { get; set; }

        public int patientId { get; set; }

        public DateTime appointmentDate { get; set; }
    }
}
