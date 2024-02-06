using System.Text.Json.Serialization;
using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Models.TransferModels.Appointments
{
    public class AppointmentDTO(DateTime time, int patientId, int doctorId, AppointmentType type, Doctor doctor, Patient patient)
    {

        public DateTime time { get; set; } = time;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppointmentType appointmentType { get; set; } = type;

        public string doctor { get; set; } = doctor.FullName;
        public int doctorId { get; set; } = doctorId;
        public string patient { get; set; } = patient.FullName;
        public int patientId { get; set; } = patientId;

    }
}
