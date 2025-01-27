using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("Doctors")]
    public class Doctor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }       

        [Column("fullname")]  
        public string FullName { get; set; }
        [Column("booking")]
        public List<Appointment> Appointments { get; set; }
    }
}
