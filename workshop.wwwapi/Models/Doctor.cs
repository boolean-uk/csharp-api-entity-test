using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("doctors")]
    public class Doctor
    {
        [Key]
        [Column("doctor_id")]
        public int Id { get; set; }
        [Column("doctor_name")]
        public string FullName { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
