namespace workshop.wwwapi.Models.DTOs
{
    public class PatientAppointmentDTO
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
