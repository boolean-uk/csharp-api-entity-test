namespace workshop.wwwapi.DTOs
{
    public record CreatePatientPayload(string FullName);
    public record CreateDoctorPayload(string FullName);

    public record CreatePrescriptionPayload(int Quantity, string Notes);

    public record CreateMedicinePayload(string Name);
    public record CreateAppointmentPayload(int doctorId, int patientId, int prescriptionId, string type);

}
