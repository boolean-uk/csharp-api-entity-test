using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.Domain
{
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("doctor_id")]
        [ForeignKey("DoctorID")]
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }

        [Column("patient_id")]
        [ForeignKey("PatientID")]
        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        [Column("appointment_time")]
        public DateTime AppointmentTime { get; set; }

    }
}
