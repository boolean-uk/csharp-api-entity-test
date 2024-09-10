using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }

        List<MedicinOnPrescription> Medicins = new List<MedicinOnPrescription>();
    }
}
