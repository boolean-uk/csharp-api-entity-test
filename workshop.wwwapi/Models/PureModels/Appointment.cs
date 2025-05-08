using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using workshop.wwwapi.Models.JunctionTable;

namespace workshop.wwwapi.Models.PureModels
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Column("appointment_id")]
        public int Id { get; set; }

        [Column("appointment_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppointmentType AppointmentType {  get; set; }

        [Column("booking_time")]
        public DateTime Booking { get; set; }

        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }

        public Doctor Doctor { get; set; }

        public Patient Patient { get; set; }

    }
}
