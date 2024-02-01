using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
  

    [Table("Patients")]
    public class Patient
    {
        [Key]
        [Column("patient_id")]
        public int Id { get; set; }
        
        [Column("full_name")]
        public string FullName { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}
