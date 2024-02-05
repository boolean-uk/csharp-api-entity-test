using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("Prescription")]
    public class Prescription
    {
        [Column("id")]
        public int Id { get; set; }

        public IEnumerable<Medicine> Medicines { get; set; }

        [Column("appointment_id")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
