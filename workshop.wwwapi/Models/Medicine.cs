using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicines")]
    public class Medicine
    {
        [Key]
        [Column("id")] 
        public int Id { get; set; }

        [Column("name")] 
        public string Name { get; set; }

        [Column("instructions")] 
        public string Instruction { get; set; }

        [Column("quantity")] 
        public int Quantity { get; set; }


        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();

    }
}
