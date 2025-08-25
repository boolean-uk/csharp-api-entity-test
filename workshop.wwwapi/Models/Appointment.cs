using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {

        [Key]
        [Column("appointment_id")]
        public int Id { get; set; }
        [Column("booking")]
        public DateTime Booking { get; set; }
        [Column("doctor")]
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [Column("patient")]
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }


    }
}
