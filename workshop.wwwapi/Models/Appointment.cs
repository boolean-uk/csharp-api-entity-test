using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using workshop.wwwapi.Models.DTOs;

namespace workshop.wwwapi.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }

        [ForeignKey("Doctor")]
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("Patient")]
        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Prescription")]
        [Column("prescription_id")]
        public int? PrescriptionId { get; set; }
        //public Prescription? Prescription { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    }
}
