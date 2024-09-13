namespace workshop.wwwapi.ViewModels
{
    public class PrescriptionPostModel
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int MedicineId { get; set; }
        public int DoseInMg { get; set; }
        public string Instruction { get; set; }
    }
}
