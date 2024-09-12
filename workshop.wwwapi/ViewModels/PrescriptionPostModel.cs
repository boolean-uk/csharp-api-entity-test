using workshop.wwwapi.Models;

namespace workshop.wwwapi.ViewModels
{
    public class PrescriptionPostModel
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public List<PrescribedMedicinePostModel> PrescribedMedicineList { get; set; } = new List<PrescribedMedicinePostModel>();

    }
}
