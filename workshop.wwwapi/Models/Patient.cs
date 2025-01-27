using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    //

    [Table("patient_table")]
    public class Patient
    {

        [Key]
        [Column ("patient_id")]
        public int Id { get; set; }

        [Column ("full_name")]
        public string FullName { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
