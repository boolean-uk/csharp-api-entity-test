namespace workshop.wwwapi.Models
{
    public class AppointmentWhitoutPrescription
    {
        public int Id { get; set; }
        public DateTime Booking { get; set; }
        public DoctorWhithoutAppointment Doctor { get; set; }
        public PatientWhithoutAppointment Patient { get; set; }
    }
}
