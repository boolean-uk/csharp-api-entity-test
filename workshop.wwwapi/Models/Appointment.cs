using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("appointment")]
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }

        [Column("doctor_id")]
        public int DoctorId { get; set; }

        // Navigation property for Doctor
        public Doctor Doctor { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }

        // Navigation property for Patient
        public Patient Patient { get; set; }

        // Type  of appointment
        [Column("type")]
        public AppointmentType Type { get; set; }
    }
}
