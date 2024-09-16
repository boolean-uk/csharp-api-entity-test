using System.Text.Json.Serialization;
using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Models.TransferModels.Appointments
{
    public class AppointmentWithDoctorDTO(DateTime Time, AppointmentType type, int DoctorId, Doctor doctor)
    {
        public DateTime Time { get; set; } = Time;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppointmentType AppointmentType { get; set; } = type;

        public int DoctorId { get; set; } = DoctorId;
        public string Doctor { get; set; } = doctor.FullName;
    }
}
