namespace workshop.wwwapi.DTOs.Appointment;

public class AppointmentPost
{
    public string Doctor { get; set; }
    public string Patient { get; set; }
    public DateTime Booking { get; set; }

    public static AppointmentPost FromAppointment(Models.Appointment appointment)
    {
        return new AppointmentPost
        {
            Doctor = appointment.Doctor.FullName,
            Patient = appointment.Patient.FullName,
            Booking = appointment.Booking
        };
    }
}