namespace workshop.wwwapi.DTO;

public class PrescriptionLinePost
{
    public int MedicineId { get; set; }
    public int Quantity { get; set; }
    public string Instructions { get; set; }
}