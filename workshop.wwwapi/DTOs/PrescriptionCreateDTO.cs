namespace workshop.wwwapi.DTOs
{
    public class PrescriptionCreateDTO
    {
        public int patientId {  get; set; }
        public int doctorId { get; set; }
        public DateTime appointmentDate { get; set; }
        public PMedicinePrescriptionDTO medicinePrescription { get; set; }
    }
}
