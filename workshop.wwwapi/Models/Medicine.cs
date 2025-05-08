using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Diagnostics.HealthChecks;

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
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        public List<MedicinePrescription> MedicinePrecriptions { get; set; } = [];
        public List<Prescription> Prescriptions { get; set; } = [];
    }
}
