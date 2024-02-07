using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DatabaseModels
{
    public class Medicine
    {
        [Column("medicine_id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public List<PrescriptionMedicine> PrescriptionMedicine { get; set; } = new List<PrescriptionMedicine>();
    }
}
