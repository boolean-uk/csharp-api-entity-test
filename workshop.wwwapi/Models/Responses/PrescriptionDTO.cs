namespace workshop.wwwapi.Models.Responses
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public List<PrescriptionMedicineDTO> Medicines { get; set; } = new();
    }
}
