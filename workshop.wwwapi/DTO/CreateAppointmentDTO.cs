namespace workshop.wwwapi.DTO
{
    public class CreateAppointmentDTO
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Booking { get; set; }

    }
}
