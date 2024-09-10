using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }

        public List<MedicinOnPrescription> Medicins = new List<MedicinOnPrescription>();
    }
}
