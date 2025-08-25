public class PrescriptionMedicine
{

    //These two form the composite key
    public int PrescriptionId { get; set; }

    public int MedicineId { get; set; }

    // Navigation properties
    public Medicine Medicine { get; set; }
    public Prescription Prescription { get; set; }

    public int Quantity { get; set; }
    public string Notes { get; set; }
}
