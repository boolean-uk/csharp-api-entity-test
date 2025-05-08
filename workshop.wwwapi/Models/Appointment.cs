using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using workshop.wwwapi.Models.Prescriptions;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Key, Column("id")]
        public int Id { get; internal set; }
        [Column("booking")]
        public DateTime Booking { get; set; }
        [ForeignKey(nameof(Doctor)), Column("doctor_id_fk", Order = 0)]
        public int DoctorIdFK { get; set; }
        [ForeignKey(nameof(Patient)), Column("patient_id_fk", Order = 1)]
        public int PatientIdFK { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; } = DateTime.UtcNow;

        public Doctor Doctor { get; set; } = null;
        public Patient Patient { get; set; } = null;
        //public Prescription? prescription { get; set; } = null;
    }
}
