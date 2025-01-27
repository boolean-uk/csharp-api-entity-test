using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTO.Request.Appointment
{
    public class Create
    {
        public Create() { }
        public Create(Models.Appointment a)
        {
            Booking = a.Booking;
            DoctorId = a.DoctorId;
            PatientId= a.PatientId;
        }
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }

}
