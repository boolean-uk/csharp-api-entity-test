using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("Patient")]
    [PrimaryKey("Id")]
    public class Patient
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("FullName")]
        public string FullName { get; set; }
        [NotMapped]
        public List<Appointment> Appointments { get; set; }
    }
}
