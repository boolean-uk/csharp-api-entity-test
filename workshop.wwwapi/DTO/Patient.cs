namespace workshop.wwwapi.DTO
{
    public record PatientPost(string FirstName, string LastName);
    public record PatientView(int Id, string FullName, IEnumerable<AppointmentDoctor> Appointments);
    public record PatientInternal(int Id, string FullName);
}
