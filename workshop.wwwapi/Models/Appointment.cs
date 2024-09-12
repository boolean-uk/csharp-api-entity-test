using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("Appointments")]
    public class Appointment
    {
        [Column("apointmentDate")]
        public DateTime ApointementDate { get; set; }

        [Column("doctorid")]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        [Column("patientid")]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }

    }
}
