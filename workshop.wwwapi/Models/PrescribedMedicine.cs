using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class PrescribedMedicine
    {
        public int Id { get; set; }
        public string Instructions { get; set; }
        public int Amount { get; set; }
        public string MedicineName { get; set; }

        [ForeignKey(nameof(Prescription))]
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

    }
}
