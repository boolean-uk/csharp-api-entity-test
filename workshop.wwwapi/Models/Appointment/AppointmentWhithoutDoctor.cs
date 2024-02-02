namespace workshop.wwwapi.Models
{
    public class AppointmentWhithoutDoctor
    {
        public DateTime Booking { get; set; }

        public PatientWhithoutAppointment Patient { get; set; }
    }
}
