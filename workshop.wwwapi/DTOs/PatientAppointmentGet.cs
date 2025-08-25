namespace workshop.wwwapi.DTOs
{
    public class PatientAppointmentGet
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
