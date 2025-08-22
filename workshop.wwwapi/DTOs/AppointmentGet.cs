namespace workshop.wwwapi.DTOs
{
    public class AppointmentGet
    {
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }

        public string PatientName { get; set; }
    }
}
