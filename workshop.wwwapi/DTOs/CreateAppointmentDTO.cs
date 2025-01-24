namespace workshop.wwwapi.DTOs
{
    public class CreateAppointmentDTO
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}
