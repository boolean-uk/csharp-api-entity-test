using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("Medecines")]
    public class Medicine
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("medecineprescriptions")]
        public ICollection<MedicinePrescription> MedicinePrescriptions { get; set; }
    }
}
