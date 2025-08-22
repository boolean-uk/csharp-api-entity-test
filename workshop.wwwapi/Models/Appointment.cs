using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Enums;

namespace workshop.wwwapi.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Column("patient_id")]
        public int PatientID { get; set; }
        public Patient Patient { get; set; }
        [Column("doctor_id")]
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
        [Column("booking_time")]
        public DateTime Booking {  get; set; }
        [Column("appointment_type")]
        public AppointmentType Type { get; set; }
    }
}
