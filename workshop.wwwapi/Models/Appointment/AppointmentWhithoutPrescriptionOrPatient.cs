namespace workshop.wwwapi.Models
{
    public class AppointmentWhithoutPrescriptionOrPatient
    {
        public int Id { get; set; }

        public DateTime Booking { get; set; }

        //public AppointmentType Type { get; set; }

        public DoctorWhithoutAppointment Doctor { get; set; }
    }
}
