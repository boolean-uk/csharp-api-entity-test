using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    public class Appointment
    {
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }
        [Column("booking")]
        public DateTime Booking { get; set; }
        public Patient Patient { get; set; } 
        public Doctor Doctor { get; set; } 


    }

    public class PatientAppointmentDto
    {
        public DateTime Booking { get; set; }
        [JsonIgnore]
        public int DoctorId { get; set; }
        public DoctorDisplayDto DoctorDto { get; set; }

    }

    public class DoctorAppointmentDto
    {
        public DoctorDisplayDto Doctor { get; set; }
        public DateTime Booking { get; set; }
        [JsonIgnore]
        public int PatientId { get; set; }
        public PatientDisplayDto Patient { get; set; }
    }
}
