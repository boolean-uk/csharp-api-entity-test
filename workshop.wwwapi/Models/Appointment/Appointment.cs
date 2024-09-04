using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

public enum AppointmentType
{
    [EnumMember(Value = "Online")]
    [Description("Online")]
    Online = 0,

    [EnumMember(Value = "InPerson")]
    [Description("In Person")]
    InPerson = 1
}

namespace workshop.wwwapi.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("booking")]
        public DateTime Booking { get; set; }

        [Column("type")]
        public AppointmentType Type { get; set; }

        [Column("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public Prescription? Prescription { get; set; }
    }
}
