using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Column("patient_name")]
        public string FullName { get; set; }
        [Column("booking")]
        public List<Appointment> Appointments { get; set; }
      

    }
}
