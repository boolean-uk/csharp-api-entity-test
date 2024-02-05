using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicines")]
    public class Medicine
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        public ICollection<PrepMedicines> Prepscriptions { get; set; } = new List<PrepMedicines>();
    }
}