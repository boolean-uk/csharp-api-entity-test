using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("Doctors")]
    public class Doctor
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("fullname")]
        public string FullName { get; set; }

        [Column("appointments")]
        public ICollection<Appointment> Appointments { get; set; }
    }
}
