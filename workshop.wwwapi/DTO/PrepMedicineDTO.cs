using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PrepMedicineDTO
    {
        public int Id { get; set; }
        //public int PrescriptionId { get; set; }
        //public PrescriptionDTO Prescription { get; set; }
        public int MedicineId { get; set; }
        public MedicineDTO Medicine { get; set; }

        public PrepMedicineDTO(PrepMedicines prepMedicine)
        {
            Id = prepMedicine.Id;
            MedicineId = prepMedicine.MedicineId;
            Medicine = new MedicineDTO(prepMedicine.Medicine);
        }
    }
}