namespace workshop.wwwapi.DTOs;

public class AppointmentDTO(string name, DateTime booking)
{
    public string Name { get; set; } = name;
    public DateTime AppointmentDate { get; set; } = booking;
}