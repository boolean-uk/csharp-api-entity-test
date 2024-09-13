using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class DTOAppointmentWithoutPatient
    {
        public string Booking {  get; set; }
        public string Type { get; set; }
        public DTODoctorWithoutAppointment Doctor { get; set; }
    }
}
