using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    
    [Table("patients")]
    public class Patient
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string FullName { get; set; }
    }

    public class PatientAppointments
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
