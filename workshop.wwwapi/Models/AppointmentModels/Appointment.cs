using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.DoctorModels;
using workshop.wwwapi.Models.PatientModels;

namespace workshop.wwwapi.Models.AppointmentModels
{
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [Key]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [Key]
        [Column("booking")]
        public DateTime Booking { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}
