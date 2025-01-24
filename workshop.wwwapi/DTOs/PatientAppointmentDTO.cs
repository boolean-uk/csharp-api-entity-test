namespace workshop.wwwapi.DTOs
{
    public class PatientAppointmentDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}
