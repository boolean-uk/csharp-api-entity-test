using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    [Table("DOCTOR")]
    public class DoctorDTO
    {
        [Key]
        [Column("DOCTOR_ID")]
        public int Id { get; set; }
        [Column("FULLNAME")]
        public string FullName { get; set; }

        List<Appointment> Appointments { get; set; }
    }
}
