using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    [Table("perscription")]
    public class Perscription
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("doctorid")]
        [Column("doctorid")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("patientid")]
        [Column("patientid")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [JsonIgnore]
        public ICollection<MedicinPerscription> medicinPerscriptions { get; set; } = new List<MedicinPerscription>();

    }
}
