using System.ComponentModel.DataAnnotations.Schema; 
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    public class Doctor
    {        
        public int Id { get; set; }        
        public string FullName { get; set; }

        //[JsonIgnore]
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
