using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("doctors")]
    public class Doctor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("fullname")]
        public string FullName { get; set; }

        [Column("appointments")]
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
