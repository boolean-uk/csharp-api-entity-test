namespace workshop.wwwapi.Endpoints
{
    public record CreatePatientPayload(string FullName);
    public record CreateDoctorPayload(string FullName);
    public record CreateAppointmentPayload(DateTime Booking, int DoctorId, int PatientId, string Type, int PrescriptionId);
    public record CreatePrescriptionPayload(int Quantity, string Notes);
    public record CreateMedicinePayload(string Name);
}