using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data.DTO
{
    public class AppointmentPatientDTO
    {

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime Booking { get; set; }
        public string AppointmentType { get; set; }

    

    }
}
