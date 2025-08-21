using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    //[Table("Patients")]
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Column("Full_name")]
        public string FullName { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
