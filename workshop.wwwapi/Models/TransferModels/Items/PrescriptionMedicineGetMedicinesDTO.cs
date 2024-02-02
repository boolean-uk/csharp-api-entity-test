using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Models.TransferModels.Items
{
    public class PrescriptionMedicineGetMedicinesDTO(int Id, Medicine medicines)
    {
        public int MedicineId { get; set; } = Id;

        public MedicineDTO Medicine { get; set; } = new MedicineDTO(medicines.Id, medicines.Name);
        //public MedicineDTO Medicine { get; set; } = new MedicineDTO(medicines.Id, medicines.Name, medicines.Amount, medicines.Instructions);
    }
}
