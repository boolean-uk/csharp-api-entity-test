namespace workshop.wwwapi.DTO
{
    public class AppointmentDTO
    {
        public DateTime Booking {  get; set; }

        public PatientDTOwithoutAppointment Patient { get; set; }

        public DoctorDTOWithoutAppointment Doctor { get; set; }
    }
}
