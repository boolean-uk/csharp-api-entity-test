using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly   
    [Table("patient")] 
    public class Patient
    {
        [Column("id")]        
        public int Id { get; set; }
        [Column("full_name")]        
        public string FullName { get; set; }

        public ICollection<Appointment> Appointments {get; set;} = [];
    }
}
