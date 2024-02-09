using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.Prescriptions
{
    [Table("Prescriptions")]
    public class Prescription
    {
        private static int _id = 1;
        public Prescription()
        {
            Id = _id++;
        }

        [Key, Column("id")]
        public int Id { get; internal set; }

        [ForeignKey(nameof(PrescriptionContents)), Column("prescription_content_id_fk", Order = 0)]
        public int prescriptionContentIdFK;
        public PrescriptionContents prescriptionContents { get; set; } = null;
        [ForeignKey(nameof(Appointment)), Column("appointment_id_fk", Order = 1)]
        public int AppointmentIdFK { get; set; }
        public Appointment appointment { get; set;} = null;

    }
}
