using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class MedicineResponseDTO
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
        public string Notes { get; set; }
        public List<PrepMedicineDTO> Prepscriptions { get; set; } = new List<PrepMedicineDTO>();

        public MedicineResponseDTO(Medicine medicine)
        {
            Id = medicine.Id;
            Notes = medicine.Notes;
            Quantity = medicine.Quantity;
            foreach (var prescription in medicine.Prepscriptions)
                Prepscriptions.Add(new PrepMedicineDTO(prescription));
        }

        public static List<MedicineResponseDTO> FromRepository(IEnumerable<Medicine> prescriptions)
        {
            var results = new List<MedicineResponseDTO>();
            foreach (var prescription in prescriptions)
                results.Add(new MedicineResponseDTO(prescription));
            return results;
        }

        //public static MedicineResponseDTO FromARepository(Prescription prescription)
        //{
        //    MedicineResponseDTO result = new MedicineResponseDTO(prescription);
        //    return result;
        //}
    }
}
