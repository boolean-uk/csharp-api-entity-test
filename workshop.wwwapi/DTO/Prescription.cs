namespace workshop.wwwapi.DTO
{
    public record PrescriptionPost(double Quantity, string Notes, int AppointmentDoctorId, int AppointmentPatientId, int MedicineId);
    public record PrescriptionView(int Id, double Quantity, string Notes, AppointmentDoctorPatient Appointment, IEnumerable<MedicineInternal> Medicines);
    public record PrescriptionInternal(int Id, double Quantity, string Notes);
}
