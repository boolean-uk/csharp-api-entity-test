using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace workshop.wwwapi.ViewModels
{
    public class AppointmentPostModel
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public int typeCode { get; set; }
        public int doctorId { get; set; }
        public int patientId { get; set; }
    }
}
