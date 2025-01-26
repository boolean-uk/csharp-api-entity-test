using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("appointmentDate")]
        public DateTime appointmentDate { get; set; } = DateTime.UtcNow;

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int PatientId { get; set; }

        // Navigasjons-egenskaper for relasjoner
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}

