using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("Patients")]
    public class Patient
    {
        [Required]
        [Column("Id", TypeName = "int")]
        [Key]
        public int Id { get; set; }      
        
        [Required]
        [Column("FullName")]
        public string FullName { get; set; }

        [Column("Appointments")]
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
