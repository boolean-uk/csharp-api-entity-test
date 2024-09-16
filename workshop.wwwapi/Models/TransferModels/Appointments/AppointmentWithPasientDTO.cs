using System.Text.Json.Serialization;
using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Models.TransferModels.Appointments
{
    public class AppointmentWithPasientDTO(DateTime Time, AppointmentType type, int patientId, Patient patient)
    {
        public DateTime Time { get; set; } = Time;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppointmentType AppointmentType { get; set; } = type;
        public int PatientId { get; set; } = patientId;

        public string Patient { get; set; } = patient.FullName;
    }
}
