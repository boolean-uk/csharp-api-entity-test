using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class Doctor
    {    
        [Column("id", TypeName = "int")]
        public int Id { get; set; }     
        
        [Column("name", TypeName = "varchar(100)")]
        public string FullName { get; set; }
        
        [Column("appointments")]
        public ICollection<Appointment> Appointments { get; set; }
    }
}
