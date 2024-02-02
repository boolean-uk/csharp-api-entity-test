using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs.Prescriptions
{
    public class GetPrescriptionDTO
    {
        public List<GetMedicineDTO> Medicines { get; set; }
    }
}
