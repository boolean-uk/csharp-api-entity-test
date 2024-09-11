using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models
{
    [Table("prescription")]
    public class Prescription
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        public List<Medicine> Medicines { get; set; } = new List<Medicine>();

        [ForeignKey("Appointment")]
        [Column("AppointmentId")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
