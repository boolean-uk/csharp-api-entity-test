using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string FullName { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
