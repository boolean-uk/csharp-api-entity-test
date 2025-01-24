using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTO
{
    public class PrescriptionView
    {
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
