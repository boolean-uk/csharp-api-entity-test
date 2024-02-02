namespace workshop.wwwapi.Models.TransferInputModels
{
    public class AppointmentInputDTO
    {
        public DateTime Booking { get; set; }

        public int doctorId { get; set; }

        public int patientId { get; set; }
    }
}
