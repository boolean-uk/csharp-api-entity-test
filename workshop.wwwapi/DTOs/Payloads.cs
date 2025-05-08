namespace workshop.wwwapi.DTOs
{
    public record CreatePatientPayload(string Name);
    public record CreateDoctorPayload(string Name);
    public record CreateAppointmentPayload(int patientId, int doctorId, DateTime Booking);
}

