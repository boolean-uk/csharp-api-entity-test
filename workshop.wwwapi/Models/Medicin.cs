using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    public class Medicin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        List<MedicinOnPrescription> Prescriptions { get; set; } = new List<MedicinOnPrescription>();
    }
}
