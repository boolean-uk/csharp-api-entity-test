namespace workshop.wwwapi.Models.DTOS
{
    public class AppointmentDoctorDTO
    {
        public DateTime Booking { get; set; }
        public DoctorBaseDTO Doctor { get; set; }

        public AppointmentDoctorDTO(Appointment appointment, DoctorBaseDTO doctor)
        {
            Booking = appointment.Booking;
            Doctor = doctor;
        }
    }
}
