using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("full_name", TypeName = "varchar(255)")]
        public string FullName { get; set; }

        // Navigation property
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public Doctor(string name)
        {
            FullName = name;
            Appointments = new List<Appointment>();
        }
        public Doctor() { }
    }
}
