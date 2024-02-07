using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    [Table("appointments")]
    [PrimaryKey("Id")]
    public class Appointment
    {
        [Column("a_id")]
        public int Id { get; set; }

        [Column("a_fk_doctor_id")]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Column("a_fk_patient_id")]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Column("a_booking")]
        public DateTime Booking { get; set; }

        [Column("a_appointment_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppointmentType AppointmentType { get; set; }
    }
}
