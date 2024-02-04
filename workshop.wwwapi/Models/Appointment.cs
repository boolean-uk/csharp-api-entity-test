using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    /// <summary>
    /// Basically a joint table of Doctor-Patient
    /// </summary>
    [Table("appointment")]
    public class Appointment
    {
       /* [Column("id")]          //By convention, a property named Id or <type name>Id will be configured as the primary key of an entity.
        [Key]
        public int Id { get; set; }*/
       
       
        [Column("date",TypeName = "Date")]
        public DateTime Booking { get; set; }

        //[Column("doctor_id")]
        [ForeignKey("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Column("appointment type")]
        public AppointmentType Appointmenttype { get; set; }    

    }
}
