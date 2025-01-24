namespace workshop.wwwapi.DTOs
{
    public class DoctorAppointmentDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}
