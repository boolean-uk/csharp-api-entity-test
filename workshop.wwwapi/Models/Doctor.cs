using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("Doctors")]
    public class Doctor
    {
        [Key]
        [Column("doctor_id")]
        public int Id { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}
