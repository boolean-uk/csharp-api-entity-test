namespace workshop.wwwapi.Models.DTOS
{
    public class AppointmentPatientDTO
    {
        public DateTime Booking { get; set; }
        public PatientBaseDTO Patient { get; set; }

        public AppointmentPatientDTO(Appointment appointment, PatientBaseDTO patient)
        {
            Booking = appointment.Booking;
            Patient = patient;
        }
    }
}
