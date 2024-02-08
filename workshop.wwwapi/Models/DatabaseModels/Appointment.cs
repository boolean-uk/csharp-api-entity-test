using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DatabaseModels
{
    [PrimaryKey(nameof(DoctorId), nameof(PatientId))]
    [Table("appointments")]
    public class Appointment
    {
        [Column("booking", TypeName = "date")]
        public DateTime Booking { get; set; }

        [ForeignKey("Doctor")]
        [Column("doctorid")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("Patient")]
        [Column("patientid")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Perscription")]
        [Column("perscriptionid")]
        public int PerscriptionId { get; set; }
        public Perscription Perscription { get; set; }


    }
}
