using System.Diagnostics.Eventing.Reader;
using workshop.wwwapi.Enums;

namespace workshop.wwwapi.DTOs.PatientDTO
{
    public class PatientAppointmentGet
    {
        public int Id { get; set; }
        public DateTime Booking { get; set; }
        public AppointmentType Type { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
    }
}
