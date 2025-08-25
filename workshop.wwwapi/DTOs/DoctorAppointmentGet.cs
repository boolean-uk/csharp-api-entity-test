namespace workshop.wwwapi.DTOs
{
    public class DoctorAppointmentGet
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
