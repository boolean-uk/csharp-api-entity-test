namespace workshop.wwwapi.Models.DTO
{
    public class AppointmentDTO
    {
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public DateTime Booking { get; set; }

        public AppointmentDTO(string doctorname, string patientname, DateTime booking)
        {
            DoctorName = doctorname;
            PatientName = patientname;
            Booking = booking;
        }
    }
}