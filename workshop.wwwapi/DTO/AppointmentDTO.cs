
public class AppointmentDto
{
    public int Id { get; set; }
    public DateTime? Booking { get; set; }
    public DoctorDTO Doctor { get; set; }
    public PatientDTO Patient { get; set; }
}