using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly  
    [Table("doctor")]  
    [PrimaryKey(nameof(Id))]
    public class Doctor
    {        
        [Column("id")]
        public int Id { get; set; }
        [Column("fullName")]        
        public string FullName { get; set; }
        [NotMapped]
        public List<Appointment> Appointments {get;set;} = new List<Appointment>();
    }
}
