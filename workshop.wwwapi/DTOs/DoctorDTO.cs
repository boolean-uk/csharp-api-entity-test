namespace workshop.wwwapi.DTOs;

public class DoctorDTO(string name, List<AppointmentDTO> appointments)
{
    public string FullName { get; set; } = name;
    public List<AppointmentDTO> Appointments { get; set; } = appointments;
}