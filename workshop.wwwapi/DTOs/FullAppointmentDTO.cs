namespace workshop.wwwapi.DTOs;

public class FullAppointmentDTO(string patientName, string doctorName, DateTime booking)
{
    public string PatientName { get; set; } = patientName;
    public string DoctorName { get; set; } = doctorName;
    public DateTime Booking { get; set; } = booking;
}