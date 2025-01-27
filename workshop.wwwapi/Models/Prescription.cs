using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    public class Prescription
    {
        public int Id { get; set; } 
        public DateTime IssueDate { get; set; }

        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int PatientId { get; set; }

        public virtual Appointment Appointment { get; set; }

        public ICollection<MedicinePrescription> MedicinePrescriptions { get; set; } = new List<MedicinePrescription>();
    }
}
