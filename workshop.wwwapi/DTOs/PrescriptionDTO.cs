namespace workshop.wwwapi.DTOs
{
    public class PrescriptionDTO
    {
        public AppointmentDTO Appointment { get; set; }
        public ICollection<PMedicinePrescriptionDTO> MedecinePerscriptions { get; set; }
    }
}
