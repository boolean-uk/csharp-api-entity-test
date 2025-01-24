using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescriptions")]
    public class Prescription
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("appointment_id")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public List<Medicine> Medicines { get; set; } = new List<Medicine>();
        public List<MedicinePresctiption> MedicinePresciptions { get; set; } = new List<MedicinePresctiption>();
    }
}
