using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    [Table("medicine_prescriptions")]
    
    public class Prescription
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("note")]
        public string Note { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("medicine_id")]
        [ForeignKey("medicines")]
        public int MedicineId { get; set; }

        [Column("appointment_id")]
        [ForeignKey("appointments")]
        public int AppointmentId { get; set; }
        public Medicine Medicine { get; set; }
        public Appointment Appointment { get; set; } = null!;

    }

    public class PrescriptionPost
    {
        public string Note { get; set; }
        public int Quantity { get; set; }
    }


}
