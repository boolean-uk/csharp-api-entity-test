using Swashbuckle.AspNetCore.Annotations;

namespace workshop.wwwapi.DTO
{
    public class AppointmentPost
    {
        public DateTime dateTime { get; set; }
        public int doctorID { get; set; }
        public int patientID { get; set; }
    }
}
