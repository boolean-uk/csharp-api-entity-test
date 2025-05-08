using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DTO
{
    public class PrescriptionDto
    {
        public string Instruction { get; set; }

        public int DocotrId { get; set; }

        public int PatientId { get; set; }

        public int medicineId { get; set; }
    }
}
