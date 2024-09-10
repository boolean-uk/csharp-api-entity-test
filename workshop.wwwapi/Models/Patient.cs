using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("PATIENT")]
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PATIENT_ID")]
        public int Id { get; set; }
        [Column("FULLNAME")]
        public string FullName { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}
