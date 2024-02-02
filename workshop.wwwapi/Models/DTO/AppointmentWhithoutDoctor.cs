namespace workshop.wwwapi.Models.DTO
{
    public class AppointmentWhithoutDoctor
    {
        public DateTime Booking { get; set; }

        public PatientWhithoutAppointment Patient { get; set; }
    }
}
