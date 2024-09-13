using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class DTOAppointment
    {
        public string Booking {  get; set; }
        public string Type { get; set; }
        public DTODoctorWithoutAppointment Doctor { get; set; }
        public DTOPatientWithoutAppointment Patient { get; set; }
        
    }
}
