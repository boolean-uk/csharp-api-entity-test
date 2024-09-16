using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescriptions")]
    [PrimaryKey("Id")]
    public class Prescription
    {
        [Column("pr_id")]
        public int Id { get; set; }
        [Column("pr_doctors_note")]
        public string DoctorsNote { get; set; }

        [Column("pr_appointment_id")]
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public ICollection<MedicinePrescription> MedicinePrescriptions { get; set; } = new List<MedicinePrescription>();
    }
}
