namespace workshop.wwwapi.DTOs;

public class PatientAppointmentDto
{
    public required string FullName { get; set; }
    
    public List<AppointmentDto> Appointments { get; set; } = [];
}