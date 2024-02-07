using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        private static int _id = 1;
        public Appointment()
        {
            Id = _id++;
        }

        [Key]
        [Column("id")]
        public int Id { get; internal set; }
        [Column("booking")]
        public DateTime Booking { get; set; }
        //[ForeignKey("doctor")]
        [Column("doctor_id_fk")]
        public int DoctorIdFK { get; set; }
        //[ForeignKey("patient")]
        [Column("patient_id_fk")]
        public int PatientIdFK { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
    }
}
