using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointment")]
    public class Appointment
    {
//        [Column("doctor_id")]
//        [ForeignKey("Doctor")]
        [Column("doctor_id"), ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        //        [Column("patient_id")]
        //        [ForeignKey("Patient")]
        [Column("patient_id"), ForeignKey("Patient")]
        public int PatientId { get; set; }

        [Column("appointment_date")]
        public DateTime DateTime { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public List<Prescription> Prescriptions { get; set; }

    }
}
