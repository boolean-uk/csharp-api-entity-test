using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Models.TransferModels.Items
{
    public class PrescriptionMedicineGetMedicinesDTO(int Amount, string Instructions, Medicine medicines)
    {
        public int Amount { get; set; } = Amount;

        public string Instructions { get; set; } = Instructions;

        public MedicineDTO Medicine { get; set; } = new MedicineDTO(medicines.Id, medicines.Name);
        //public MedicineDTO Medicine { get; set; } = new MedicineDTO(medicines.Id, medicines.Name, medicines.Amount, medicines.Instructions);
    }
}
