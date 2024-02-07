using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [PrimaryKey(nameof(Id))]
    public class Prescription
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("appointment")]
        [ForeignKey("PatientId, DoctorId")]
        public virtual Appointment Appointment { get; set; }

        [Column("medicines")]
        public List<Medicine> Medicines { get; set; } = new List<Medicine>();
    }
}
