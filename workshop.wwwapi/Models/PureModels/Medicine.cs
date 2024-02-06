using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.JunctionTable;

namespace workshop.wwwapi.Models.PureModels
{
    [Table("medicine")]
    public class Medicine
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public ICollection<PrescriptionMedicine> PrescriptionMedicine { get; set; } = new List<PrescriptionMedicine>();
    }
}
