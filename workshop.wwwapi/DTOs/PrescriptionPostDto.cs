using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class PrescriptionPostDto
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public ICollection<PrescribedMedicineDto> Medicines { get; set; } = new List<PrescribedMedicineDto>();
    }
}
