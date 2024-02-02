using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Models.TransferInputModels
{
    public class PrescriptionMedisinSetMedisinInputDTO(int prescriptionId, int amount, string instructions, int medicineId)
    {
        public int PrescriptionId { get; set; } = prescriptionId;

        public int MedicineId { get; set; } = medicineId;

        public int Amount { get; set; } = amount;

        public string Instructions { get; set; } = instructions;
    }
}
