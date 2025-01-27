using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointment")]
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }

        [Key]
        [Column("doctor_id")]
        [ForeignKey("doctor")]
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        [Key]
        [Column("patient_id")]
        [ForeignKey("patient")]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }


    }
}
