using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string FullName { get; set; }

        // Navigation property
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public Patient(string Fullname)
        {
            this.FullName = Fullname;
        }
        public Patient() { }
    }
}
