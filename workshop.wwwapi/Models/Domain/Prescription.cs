using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.Domain
{
    [Table("prescriptions")]
    public class Prescription
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("appointment_id")]
        [ForeignKey("AppointmentID")]
        public int AppointmentID { get; set; }
        public Appointment Appointment { get; set; }

        public ICollection<PrescriptionMedicine> Medicines { get; set; }
    }
}
