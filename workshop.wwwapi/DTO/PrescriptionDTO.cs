namespace workshop.wwwapi.DTO
{
    public class PrescriptionDTO
    {
        public DateTime IssueDate { get; set; }
        public AppointmentDTO Appointment { get; set; }
        public IEnumerable<MedicinePrescriptionDTO> MedicinePrescriptions { get; set; }
    }
}
