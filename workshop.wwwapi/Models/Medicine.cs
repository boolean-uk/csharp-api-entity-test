using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicines")]
    public class Medicine
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public List<Prescription> Prescription { get; set; } = new List<Prescription>();
        public List<MedicinePresctiption> MedicinePresctiptions { get; set; } = new List<MedicinePresctiption>();
    }
}
