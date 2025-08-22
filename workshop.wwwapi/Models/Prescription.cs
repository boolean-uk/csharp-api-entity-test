using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescriptions")]
    public class Prescription
    {
        [Key]
        public int Id { get; set; }
        [Column("appointment_id")]
        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; }
        [Column("medicine_id")]
        public int MedicineId { get; set; }

        public List<Medicine> Medicine { get; set; } = new();
    }
}
