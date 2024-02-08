using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescriptions")]
    public class Prescription
    {
        [Key]
        [Column("id")]
        public int PrescriptionId { get; set; }

        [Column("notes")]
        public string? Notes { get; set; }

        [Column("appointment_id")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        // Navigation property for many-to-many relationship
        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}

