using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.JunctionTable;

namespace workshop.wwwapi.Models.PureModels
{
    [Table("prescription")]
    public class Prescription
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("doctor_id")]
        [ForeignKey("doctors")]
        public int DoctorId { get; set; }

        [Column("patient_id")]
        [ForeignKey("patients")]
        public int PatientId { get; set; }

        [Column("appointment_id")]
        [ForeignKey("appointments")]
        public int AppointmentId { get; set; }

        [ForeignKey("AppointmentId, DoctorId, PatientId")]
        //[ForeignKey("DoctorId, PatientId")]
        public Appointment Appointment { get; set; }

        public ICollection<PrescriptionMedicine> PrescriptionMedicine { get; set; } = new List<PrescriptionMedicine>();
    }
}
