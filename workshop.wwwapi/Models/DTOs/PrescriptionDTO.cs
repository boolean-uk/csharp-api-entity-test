namespace workshop.wwwapi.Models.DTOs
{
    public class PrescriptionDTO
    {
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public List<MedicineDTO> Medicines { get; set; }
    }
}
