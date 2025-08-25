namespace workshop.wwwapi.DTOs;

public class AppointmentDto
{
    public DoctorDto Doctor { get; set; }
    
    public PatientDto Patient { get; set; }
    
    public DateTime AppointmentDate { get; set; }
}