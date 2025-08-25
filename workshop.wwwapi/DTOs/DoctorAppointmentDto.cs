namespace workshop.wwwapi.DTOs;

public class DoctorAppointmentDto
{
    public required string FullName { get; set; }
    
    public List<AppointmentDto> Appointments { get; set; } = [];
}