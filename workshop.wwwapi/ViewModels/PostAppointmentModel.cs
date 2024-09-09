namespace workshop.wwwapi.ViewModels;

public class PostAppointmentModel
{
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime AppointmentTime { get; set; }
}