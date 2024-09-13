using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class DTOAppointmentWithoutDoctor
    {
        public string Booking { get; set; }
        public string Type { get; set; }
        public DTOPatientWithoutAppointment Patient { get; set; }
    }
}