using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.InputObject
{
    public class InputAppointment
    {
        public DateTimeOffset Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
