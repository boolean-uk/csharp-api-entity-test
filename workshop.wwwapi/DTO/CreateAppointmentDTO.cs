public class CreateAppointmentDto
{
    public DateTime? Booking { get; set; } 
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
}