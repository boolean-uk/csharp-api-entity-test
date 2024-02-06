using System.Runtime.Serialization;

namespace workshop.wwwapi.Models
{
    public enum AppointmentType
    {
        [EnumMember(Value = "Physical meeting with doctor.")]
        InPerson,
        [EnumMember(Value = "Online text based conversation with doctor.")]
        OnlineChat,
        [EnumMember(Value = "Online meeting with doctor.")]
        OnlineCall,
        [EnumMember(Value = "Phonecall with doctor.")]
        Phone
    }
}
