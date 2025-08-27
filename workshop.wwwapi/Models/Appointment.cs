using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    //[PrimaryKey(nameof(DoctorId), nameof(PatientId))]
    public class Appointment
    {

        [Column("booking_datetime")]
        public DateTime Booking { get; set; }

        [Key]
        //[ForeignKey("Doctors")]
        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [Key]
        //[ForeignKey("Patients")]
        [Column("patient_id")]
        public int PatientId { get; set; }


    }
}
