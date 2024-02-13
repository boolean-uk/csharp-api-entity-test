using workshop.wwwapi.Models.MedicineModels;

namespace workshop.wwwapi.Models.PrescriptionModels.DTO
{
    public class MedicinePrescriptionDto
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }

        public static MedicinePrescriptionDto Create(Medicine medicine)
        {
            return new MedicinePrescriptionDto
            {
                MedicineId = medicine.MedicineId,
                Name = medicine.Name
            };
        }
    }
}
