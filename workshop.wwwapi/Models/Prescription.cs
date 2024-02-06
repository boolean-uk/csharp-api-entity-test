using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("Prescription")]
    public class Prescription
    {
        [Column("id")]
        public int Id { get; set; }
               
        [ForeignKey("Appointment")]
        public int AppointmentId {  get; set; }
        public Appointment Appointment { get; set; }
        public ICollection<MedicinePrescription> MedicinePrescriptions { get; set; } = new List<MedicinePrescription>();

    }
}
