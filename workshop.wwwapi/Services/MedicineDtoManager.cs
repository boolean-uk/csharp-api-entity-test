using workshop.wwwapi.Models;

namespace workshop.wwwapi.Services
{
    public class MedicineDtoManager
    {
        public static OutputMedicine Convert(Medicine medicine)
        {
            return new OutputMedicine
            {
                Id = medicine.Id,
                Name = medicine.Name,
                Quantity = medicine.Quantity,
                Notes = medicine.Notes
            };
        }
        public static IEnumerable<OutputMedicine> Convert(IEnumerable<Medicine> medicines)
        {
            return medicines.Select(medicine => Convert(medicine));
        }

        public static MedicineWhitoutPrescription ConvertRemovePrescription(Medicine medicine)
        {
            return new MedicineWhitoutPrescription
            {
                Id = medicine.Id,
                Name = medicine.Name,
                Quantity = medicine.Quantity,
                Notes = medicine.Notes
            };
        }

        public static IEnumerable<MedicineWhitoutPrescription> ConvertRemovePrescription(IEnumerable<Medicine> medicines)
        {
            return medicines.Select(medicine => ConvertRemovePrescription(medicine));
        }
    }
}
