namespace workshop.wwwapi.Models.DataTransfer.Medicine
{
    public class MedicineDTO
    {
        public MedicineDTO(Domain.Medicine medicine)
        {
            this.ID = medicine.ID;
            this.Name = medicine.Name;
        }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
