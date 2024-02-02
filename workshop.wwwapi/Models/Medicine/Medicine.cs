using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.Intermediaries;

namespace workshop.wwwapi.Models
{
    [Table("Medicine")]
    public class Medicine
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}