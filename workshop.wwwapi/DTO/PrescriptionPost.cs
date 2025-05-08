using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTO
{
    public class PrescriptionPost
    {
        public List<int> MedicineIds { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
