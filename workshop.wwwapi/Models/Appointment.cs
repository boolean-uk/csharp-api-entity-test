using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.DTOs;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly

    [Table("appointment")]
    public class Appointment
    {
        [Key] // Set PK
        [Column("booking", TypeName ="date")] // Get column name
        public DateTime Booking { get; set; }
       
        [ForeignKey("doctor_id")]
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("patient_id")]
        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        

    }
}
