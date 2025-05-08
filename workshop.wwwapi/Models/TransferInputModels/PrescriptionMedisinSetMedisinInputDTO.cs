using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models.PureModels;
using workshop.wwwapi.Models.TransferModels.Items;

namespace workshop.wwwapi.Models.TransferInputModels
{
    public class PrescriptionMedisinSetMedisinInputDTO(int amount, string instructions, int medicineId)
    {
        public int MedicineId { get; set; } = medicineId;

        public int Amount { get; set; } = amount;

        public string Instructions { get; set; } = instructions;
    }
}
