namespace workshop.wwwapi.Models
{
    public record CreatePatientPayload(string FullName);
    public record CreateDoctorPayload(string FullName);
    public record CreateAppointmentPayload(DateTime Booking, int DoctorId, int PatientId);
}