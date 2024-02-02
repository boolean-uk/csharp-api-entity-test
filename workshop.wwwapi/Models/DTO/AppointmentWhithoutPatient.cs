namespace workshop.wwwapi.Models.DTO
{
    public class AppointmentWhithoutPatient
    {
        public DateTime Booking { get; set; }

        public DoctorWhithoutAppointment Doctor { get; set; }
    }
}
