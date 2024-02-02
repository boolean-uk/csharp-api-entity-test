namespace workshop.wwwapi.Models.DTOs;

public class AppointmentWithDoctorDTO
{
    public DateTime Booking { get; set; }
    public DoctorDTO Doctor { get; set; }

    public static AppointmentWithDoctorDTO ToDTO(Appointment appointment)
    {
        return new AppointmentWithDoctorDTO
        {
            Booking = appointment.Booking,
            Doctor = DoctorDTO.ToDTO(appointment.Doctor),
        };
    }
}
