using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointment")]
    public class Appointment
    {

        [Column("date", TypeName = "timestamp")]
        public DateTime Booking { get; set; }

        [Column("doctor_id")]
        [ForeignKey("doctor")]
        public int DoctorId { get; set; }

        [Column("patient_id")]
        [ForeignKey("patient")]
        public int PatientId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }

    }
}
