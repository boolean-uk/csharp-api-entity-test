namespace workshop.wwwapi.DTOs;

public class PatientDTO(string fullName, List<AppointmentDTO> appointments)
{
    public string FullName { get; set; } = fullName;
    public List<AppointmentDTO> Appointments { get; set; } = appointments;
}