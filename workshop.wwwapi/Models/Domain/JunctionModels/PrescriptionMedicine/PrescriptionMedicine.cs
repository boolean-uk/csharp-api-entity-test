using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.Domain
{
    [Table("prescription_medicines")]
    public class PrescriptionMedicine
    {
        [Column("prescription_id")]
        [ForeignKey("PrescriptionID")]
        public int PrescriptionID { get; set; }
        public Prescription Prescription { get; set; }

        [Column("medicine_id")]
        [ForeignKey("MedicineID")]
        public int MedicineID { get; set; }
        public Medicine Medicine { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("note_from_doctor")]
        public string NoteFromDoctor { get; set; }
    }
}
