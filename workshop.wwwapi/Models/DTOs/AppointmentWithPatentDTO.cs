namespace workshop.wwwapi.Models.DTOs;

public class AppointmentWithPatentDTO
{
    public DateTime Booking { get; set; }
    public PatientDTO Patient { get; set; }

    public static AppointmentWithPatentDTO ToDTO(Appointment appointment)
    {
        return new AppointmentWithPatentDTO
        {
            Booking = appointment.Booking,
            Patient = PatientDTO.ToDTO(appointment.Patient),
        };
    }
}
