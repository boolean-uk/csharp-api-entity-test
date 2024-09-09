using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("DOCTOR")]
    public class Doctor
    {
        [Key]
        [Column("DOCTOR_ID")]
        public int Id { get; set; }
        [Column("FULLNAME")]
        public string FullName { get; set; }

        List<Appointment> Appointments { get; set; }
    }
}
