using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("perscriptions")]
    public class Perscription
    {
        [Key]
        [Column("id")]
        public int PerscriptionId { get; set; }
        [Column("name")]
        public string Name { get; set; }

        // foreign keys
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Column("appointment_id")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public ICollection<PerscriptionMedicine> PerscriptionMedicines { get; set; }
    }
}
