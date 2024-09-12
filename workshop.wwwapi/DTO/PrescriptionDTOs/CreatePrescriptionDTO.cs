namespace workshop.wwwapi.DTO.PrescriptionDTOs
{
    public class CreatePrescriptionDTO
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public List<PrescribedMedicineDTO> PrescribedMedicines { get; set; } = new List<PrescribedMedicineDTO>();

    }
}
