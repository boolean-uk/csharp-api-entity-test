namespace workshop.wwwapi.DTOs
{
    public class Payloads
    {
        public record CreatePatientPayload(string fullName);
        public record CreateDoctorPayload(string fullName);
        public record AddAppointmentPayload(int patientId, int doctorId, DateTime appointmentDate);
    }
}
