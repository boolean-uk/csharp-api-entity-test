using workshop.wwwapi.Enums;

namespace workshop.wwwapi.DTOs
{
    public class AppointmentPost
    {
        public int DoctorID { get; set; }
        public int PatientID { get; set; }

        public DateTime Booking { get; set; }

        AppointmentType Type { get; set; }
    }
}
