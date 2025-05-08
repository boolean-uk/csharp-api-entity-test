using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    [Table("prescription_medicines")]
    public class PrescriptionMedicine
    {
        [Column("prescription_id")]
        public int PrescriptionId { get; set; }

        [Column("medicine_id")]
        public int MedicineId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [JsonIgnore]
        public Prescription Prescription { get; set; }
        [JsonIgnore]
        public Medicine Medicine { get; set; }
    }
}
