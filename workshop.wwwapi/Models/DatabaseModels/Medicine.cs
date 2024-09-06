using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DatabaseModels
{
    [Table("medicines")]
    public class Medicine
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("perscriptionid")]
        public IEnumerable<Perscription> Perscriptions { get; set; }

    }
}
