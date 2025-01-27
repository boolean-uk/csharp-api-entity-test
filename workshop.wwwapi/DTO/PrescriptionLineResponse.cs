namespace workshop.wwwapi.DTO;

public class PrescriptionLineResponse
{
    public MedicineResponse Medicine { get; set; }
    public int Quantity { get; set; }
    public string Instructions { get; set; }
}