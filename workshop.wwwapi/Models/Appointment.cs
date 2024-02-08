using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    public enum AppointmentType
    {
        InPerson,
        Online
    }

    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }
        [Column("booking")]
        public DateTime Booking { get; set; }
        public AppointmentType Type { get; set; }
        public Patient Patient { get; set; } 
        public Doctor Doctor { get; set; } 


    }

    public class DoctorAppointmentDto
    {
        public DateTime Booking { get; set; }
        public AppointmentType Type { get; set; }

        public PatientDisplayDto Patient { get; set; }
    }

    public class AppointmentPatientDto
    {
        public PatientDisplayDto Patient { get; set; }
        public DateTime Booking { get; set; }
        public AppointmentType Type { get; set; }
        [JsonIgnore]
        public int DoctorId { get; set; }
        public DoctorDisplayDto Doctor { get; set; }

    }

    public class AppointmentDoctorDto
    {
        public DoctorDisplayDto Doctor { get; set; }
        public DateTime Booking { get; set; }
        public AppointmentType Type { get; set; }
        [JsonIgnore]
        public int PatientId { get; set; }
        public PatientDisplayDto Patient { get; set; }
    }
}
