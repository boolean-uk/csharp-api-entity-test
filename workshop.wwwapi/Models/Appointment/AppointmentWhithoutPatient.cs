namespace workshop.wwwapi.Models
{
    public class AppointmentWhithoutPatient
    {
        public DateTime Booking { get; set; }

        public string Type { get; set; }

        public PrescriptionWhitoutAppointment Prescription { get; set; }

        public DoctorWhithoutAppointment Doctor { get; set; }
    }
}
