using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.Prescriptions
{
    [Table("Medicine")]
    public class Medicine
    {
        private static int _id = 1;
        public Medicine()
        {
            Id = _id++;
        }

        [Key, Column("id")]
        public int Id { get; set; }
        [Column("instructions")]
        public string Instructions { get; set; }
        public PrescriptionContents prescriptionContents { get; set; } = null;

        /*[Column("appointment_id_fk")]
        public int AppointmentIdFK { get; set; }
        public Appointment Appointment { get; set; } = null;*/
    }
}
