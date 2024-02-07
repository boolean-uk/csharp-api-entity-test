using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models;

[Table("medicine_prescriptions")]
public class MedicinePrescription
{
    [Column("ppk_medicine_Id")]
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; }
    [Column("ppk_prescription_id")]
    public int PrescriptionId { get; set; }
    public Prescription Prescription { get; set;}
    [Column("quantity")]
    public int Quantity { get; set; }
    [Column("instructions")]
    public string Instructions { get; set; }
}
