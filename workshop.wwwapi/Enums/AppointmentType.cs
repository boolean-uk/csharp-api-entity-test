using System.Text.Json.Serialization;

namespace workshop.wwwapi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AppointmentType
    {
        InPerson,
        Digital
    }
}
