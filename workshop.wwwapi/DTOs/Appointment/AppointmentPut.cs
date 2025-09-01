namespace workshop.wwwapi.DTOs.Appointment;

public class AppointmentPut
{
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime Booking { get; set; }

    public Models.Appointment ToAppointment()
    {
        return new Models.Appointment
        {
            DoctorId = DoctorId,
            PatientId = PatientId,
            Booking = Booking,
        };
    }
}