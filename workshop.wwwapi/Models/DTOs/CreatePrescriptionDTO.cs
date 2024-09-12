namespace workshop.wwwapi.Models.DTOs
{
    public class CreatePrescriptionDTO
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public int MedId { get; set; }
        public int MedAmount { get; set; }

    }
}
