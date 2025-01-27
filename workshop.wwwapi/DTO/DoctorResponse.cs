using System.Text.Json.Serialization;

namespace workshop.wwwapi.DTO;

public class DoctorResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<AppointmentResponse>? Appointments { get; set; }
}