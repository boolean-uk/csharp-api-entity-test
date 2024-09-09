using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class PatientDTO
    {
        public string Name { get; set; }    
        
       public List<Appointment> appointments { get; set; }

    }
}
