namespace workshop.wwwapi.Models
{
    public class PerscriptionDto
    {
        public int Id { get; set; }
        public IEnumerable<MedicineDto> Medicines { get; set; }
    }
}
