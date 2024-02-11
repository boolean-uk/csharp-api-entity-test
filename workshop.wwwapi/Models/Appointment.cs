using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{

    [Table("appointment")]
    public class Appointment
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("booking")]
        public DateTime Booking { get; set; }

        [Column("doctorid")]
        public int DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }

        [Column("patientid")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }
    }

}
