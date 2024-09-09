using workshop.wwwapi.Models.MedicineModels;
using workshop.wwwapi.Models.PrescriptionMedicineModels;

namespace workshop.wwwapi.Models.PrescriptionModels.DTO
{
    public class PrescriptionMedicinePrescriptionDto
    {
        public MedicinePrescriptionDto Medicine { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }


        public static PrescriptionMedicinePrescriptionDto Create(PrescriptionMedicine prescriptionMedicine)
        {

            return new PrescriptionMedicinePrescriptionDto
            {
                Quantity = prescriptionMedicine.Quantity,
                Medicine = MedicinePrescriptionDto.Create(prescriptionMedicine.Medicine),
                Notes = prescriptionMedicine.Notes
            };
            
        }
    }
}
