using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DatabaseModels
{
    [Table("perscriptions")]
    public class Perscription
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("medicines")]
        public IEnumerable<Medicine> Medicines { get; set; }
    }
}
