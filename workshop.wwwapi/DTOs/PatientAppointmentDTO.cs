namespace workshop.wwwapi.DTOs
{
    public class PatientAppointmentDTO
    {

        public int patientId { get; set; }

        public string patientFullName { get; set; }

        public DateTime appointmentDate { get; set; }
    }
}
