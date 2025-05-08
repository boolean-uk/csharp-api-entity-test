namespace workshop.wwwapi.DTO
{
    public class Payloads
    {
        public record CreatePatientPayload(string FullName);
        public record CreateDoctorPayload(string FullName);
        public record AddAppointmentPayload(int patientId, int doctorId, DateTime appointmentDate);
    }
}
