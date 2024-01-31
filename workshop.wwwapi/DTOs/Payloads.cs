namespace workshop.wwwapi.DTOs
{
    public record CreatePatientPayload(string FullName);
    public record CreateDoctorPayload(string FullName);

    public record CreateAppointmentPayload(int doctorId, int patientId);

}
