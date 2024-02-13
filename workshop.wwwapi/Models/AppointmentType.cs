using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AppointmentType
    {
        [EnumMember(Value = "Online")]
        Online,

        [EnumMember(Value = "InPerson")]
        InPerson
    }
}
