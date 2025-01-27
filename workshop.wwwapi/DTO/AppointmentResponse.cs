using System.Text.Json.Serialization;
using workshop.wwwapi.Enums;

namespace workshop.wwwapi.DTO;

public class AppointmentResponse
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AppointmentType Type { get; set; }
    public DateTime Booking { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DoctorResponse? Doctor { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PatientResponse? Patient { get; set; }
}