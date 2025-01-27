namespace workshop.wwwapi.DTO
{
    public record DoctorPost(string FirstName, string LastName);
    public record DoctorView(int Id, string FullName, IEnumerable<AppointmentPatient> Appointments);
    public record DoctorInternal(int Id, string FullName);
}
