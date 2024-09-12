using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class MedicinePrescription
    {
        [Column("med_id")]
        [ForeignKey("med_id")]
        public int MedId { get; set; }

        [Column("prescription_id")]
        [ForeignKey("prescription_id")]
        public int PrescriptionId { get; set; }

        [Column("amount")]
        public int MedAmount { get; set; }
    }
}
