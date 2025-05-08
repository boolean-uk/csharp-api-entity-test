using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescriptions")]
    public class Prescription
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        public ICollection<MedicinePrescription> MedicinePrescriptions { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}