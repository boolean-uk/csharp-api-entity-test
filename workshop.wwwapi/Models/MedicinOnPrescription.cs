using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [PrimaryKey(nameof(MedicinId), nameof(PrescriptionId))]
    public class MedicinOnPrescription
    {
        [Required]
        public int PrescriptionId { get; set; }
        [ForeignKey("PrescriptionId")]
        public Prescription Prescription { get; set; }
        [Required]
        public int MedicinId { get; set; }

        [ForeignKey("MedicinId")]
        public Medicin Medicin { get; set; }

        [Required]
        public int Cuantity { get; set; }

        public string Notes { get; set; }
    }
}
