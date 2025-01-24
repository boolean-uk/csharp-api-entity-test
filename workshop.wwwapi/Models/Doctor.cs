using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    public class Doctor
    {        
        public int Id { get; set; }        
        public string FullName { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
