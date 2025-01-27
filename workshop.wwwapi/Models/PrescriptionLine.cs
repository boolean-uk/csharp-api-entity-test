namespace workshop.wwwapi.Models;

public class PrescriptionLine
{
    public int PrescriptionId { get; set; }
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; }
    public int Quantity { get; set; }
    public string Instructions { get; set; }
}