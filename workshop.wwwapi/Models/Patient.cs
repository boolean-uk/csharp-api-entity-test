using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly  
    [Table("patient")]  
    [PrimaryKey(nameof(Id))]
    public class Patient
    {        
        [Column("id")]
        public int Id { get; set; }   
        [Column("fullName")]     
        public string FullName { get; set; }
        [NotMapped]
        public List<Appointment> Appointments {get;set;} = new List<Appointment>();
    }
}
