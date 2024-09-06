using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class Medicine
    {
        [Column("medicine_id")]
        public int Id { get; set; }
        [Column("medicine_name")]
        public string Name { get; set; }
        public List<MedicinePrescription> Prescriptions { get; set; } = new List<MedicinePrescription>();
    }
}
