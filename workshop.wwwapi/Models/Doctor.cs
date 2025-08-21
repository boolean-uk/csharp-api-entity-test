using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("doctors")]
    public class Doctor
    {
        [Key]
        [Column("doctor_id")]
        public int Id { get; set; }

        [Column("doctor_fullname")]
        public string FullName { get; set; }

        [Column("doctor_appointments")]
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
