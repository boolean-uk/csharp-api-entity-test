namespace workshop.wwwapi.Models.DTOs
{
    public class CreatePrescriptionDTO
    {
        public int AppointmentDoctorId { get; set; }
        public int AppointmentPatientId { get; set; }
        public List<int> MedicineIds { get; set; }
        public int Quantity { get; set; }
    }
}
