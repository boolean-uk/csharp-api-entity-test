using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    public class Patient
    {
        [Key]
        public int Id { get; set; }        
        public string FullName { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
