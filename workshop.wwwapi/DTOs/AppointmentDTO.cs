namespace workshop.wwwapi.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}
