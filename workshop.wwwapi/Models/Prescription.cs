using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("prescriptions")]
    public class Prescription
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<MedicinePrescription> MedicinePrescriptions { get; set; }
    }
}
