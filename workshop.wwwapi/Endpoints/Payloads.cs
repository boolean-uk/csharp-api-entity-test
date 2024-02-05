namespace workshop.wwwapi.Endpoints
{
    public record CreatePatientPayload(string FullName);
    public record CreateDoctorPayload(string FullName);
    public record CreateAppointmentPayload(DateTime Booking, int DoctorId, int PatientId);
}