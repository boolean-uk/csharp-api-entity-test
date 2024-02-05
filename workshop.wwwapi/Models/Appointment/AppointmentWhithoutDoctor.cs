namespace workshop.wwwapi.Models
{
    public class AppointmentWhithoutDoctor
    {
        public DateTime Booking { get; set; }

        //public AppointmentType Type { get; set; }

        public PatientWhithoutAppointment Patient { get; set; }

        public PrescriptionWhitoutAppointment? Prescription { get; set; }
    }
}
