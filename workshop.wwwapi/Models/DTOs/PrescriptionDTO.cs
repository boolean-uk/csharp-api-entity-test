namespace workshop.wwwapi.Models.DTOs
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public int AppointmentDoctorId { get; set; }
        public int AppointmentPatientId { get; set; }
        public DateTime AppointmentBookingTime { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public List<MedicineDTO> MedicineInfo { get; set; }
        public int Quantity { get; set; }
    }
}
