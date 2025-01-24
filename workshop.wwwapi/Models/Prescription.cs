using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    public class Prescription
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("appointment_id")]
        public Guid AppointmentId { get; set; }
        
        public Appointment Appointment { get; set; }
        public ICollection<Medicine> Medicines { get; set; }

    }
}
