using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO.PrescriptionDTOs
{
    public class GetPrescriptionDTO
    {
        public string PatientName { get; set; }
        public string DoctorName { get; set; }

        public List<PrescribedMedicineDTO> prescribedMedicines { get; set; } = new List<PrescribedMedicineDTO>();

    }
}
