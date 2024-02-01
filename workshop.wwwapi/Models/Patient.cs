using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using workshop.wwwapi.Data.DTO;

namespace workshop.wwwapi.Models
{
    
    //TODO: decorate class/columns accordingly
    [Table("patient")]
    public class Patient
    {
        [Column("patient_id")]
        public int Id { get; set; }
        [Column("patient_full_name")]
        public required string FullName { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = [];
    }
   
}
