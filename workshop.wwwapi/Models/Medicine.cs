public class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
}
