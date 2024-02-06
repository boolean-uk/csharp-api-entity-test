using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models.TransferInputModels
{
    public class AppointmentInputDTO
    {
        public DateTime Booking { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppointmentType AppointmentType { get; set; }

        public int doctorId { get; set; }

        public int patientId { get; set; }
    }
}
