using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }
        [Column("fk_doctor_id")]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [Column("fk_patient_id")]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [Column("fk_presciption_id")]
        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; }

    }
}
