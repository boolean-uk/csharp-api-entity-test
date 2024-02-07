namespace workshop.wwwapi.Models.DTO
{
    public class PrescriptionDTO
    {
        public int ID { get; set; }
        public List<PrescriptionMedicineDTO> Medicine { get; set; } = new List<PrescriptionMedicineDTO>();

    }
}
