namespace workshop.wwwapi.Models.TransferModels
{
    public class AppointmentInputDTO
    {
        public DateTime Booking { get; set; }

        public int doctorId { get; set; }

        public int patientId { get; set; }
    }
}
