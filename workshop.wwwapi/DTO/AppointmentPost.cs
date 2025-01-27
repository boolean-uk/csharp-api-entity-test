using System.Text.Json.Serialization;
using workshop.wwwapi.Enums;

namespace workshop.wwwapi.DTO;

public class AppointmentPost
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AppointmentType Type { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime Booking { get; set; }
}