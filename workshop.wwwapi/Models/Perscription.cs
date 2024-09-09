using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("perscription")]
    public class Perscription
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public List<PerscriptionMedicine> PerscriptionMedicines { get; set; }

    }
}
