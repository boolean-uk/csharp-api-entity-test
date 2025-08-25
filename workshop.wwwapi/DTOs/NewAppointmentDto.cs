namespace workshop.wwwapi.DTOs;

public class NewAppointmentDto
{
    public required int DoctorId { get; set; }
    
    public required int PatientId { get; set; }
    
    public required DateTime AppointmentDate { get; set; }
}