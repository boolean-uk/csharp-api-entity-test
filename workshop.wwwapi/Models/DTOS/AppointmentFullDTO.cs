namespace workshop.wwwapi.Models.DTOS
{
    public class AppointmentFullDTO
    {
        public DateTime Booking { get; set; }
        public DoctorBaseDTO Doctor { get; set; }
        public PatientBaseDTO Patient { get; set; }

        public AppointmentFullDTO(Appointment appointment, DoctorBaseDTO doctor, PatientBaseDTO patient)
        {
            Booking = appointment.Booking;
            Doctor = doctor;
            Patient = patient;
        }
    }
}
