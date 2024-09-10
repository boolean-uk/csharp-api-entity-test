namespace workshop.wwwapi.DTO
{
    public class PrescriptionDTO
    {
        public int appointmentId;
        public List<int> MedicinID { get; set; } = new List<int>();
        public List<MedicineDTO> Medicines { get; set; } = new List<MedicineDTO>();

    }
}
