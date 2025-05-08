using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PrescriptionDTO
    {
        public List<MedicineDTO> Medicines { get; set; } = [];
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }
}
