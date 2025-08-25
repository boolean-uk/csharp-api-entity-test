using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models;

[Table("Prescription-Medicine")]
public class PrescriptionMedicine
{
    [ForeignKey("Prescription")]
    [Column("prescription_fk")]
    public int PrescriptionId { get; set; }
    public Prescription Prescription { get; set; } = null!;
    
    [ForeignKey("Medicine")]
    [Column("medicine_fk")]
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; } = null!;

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    [MaxLength(1024)]
    public string? Notes { get; set; }
}
