using System.Text.Json.Serialization;

namespace workshop.wwwapi.DTO;

public class PatientResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<AppointmentResponse>? Appointments { get; set; }
}