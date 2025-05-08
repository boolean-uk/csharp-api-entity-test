using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointment")]
    [PrimaryKey("DoctorId", "PatientId")]
    public class Appointment
    {
        /*
        [Column("booking_id")]
        public int Id { get; set; }
        */
        [Column("booking_date")]
        public DateTime Booking { get; set; }
        [Column("doctor_id")]
        [ForeignKey ("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor {  get; set; }
        [Column("patient_id")]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Column("appointment type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppointmentType Type { get; set; }
    }
}
