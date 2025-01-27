using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentDTODoctor
    {
        public DateTime Booking {  get; set; }
        public string Name { get; set; }
        public int PatientId { get; set; }
        public Prescription Prescription { get; set; }
    }
}
