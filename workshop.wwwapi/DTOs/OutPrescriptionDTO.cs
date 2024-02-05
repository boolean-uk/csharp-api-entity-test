using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class OutPrescriptionDTO
    {
        //public int Id { get; set; }
        public ICollection<OutPrescriptionMedicineDTO> PrescriptMed { get; set; } = new List<OutPrescriptionMedicineDTO>();
    }
}
