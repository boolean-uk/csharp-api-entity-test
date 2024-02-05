using System.Text.Json.Serialization;
using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Models.TransferModels.Appointments
{
    public class AppointmentDTO(DateTime time, int patientId, int doctorId, AppointmentType type, Doctor doctor, Patient patient)
    {

        public DateTime time { get; set; } = time;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppointmentType AppointmentType { get; set; } = type;

        public string Doctor { get; set; } = doctor.FullName;
        public int doctorId { get; set; } = doctorId;
        public string Patient { get; set; } = patient.FullName;
        public int patientId { get; set; } = patientId;

    }
}
