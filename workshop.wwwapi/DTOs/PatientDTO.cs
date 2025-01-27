using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<AppointmentWithDoctor> appointments {  get; set; } 
    }
}
