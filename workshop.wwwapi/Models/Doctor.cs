using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("doctor")]
    public class Doctor
    {
        [Column("doctor_id")]
        public int Id { get; set; }

        [Column("doctor_fullName")]
        public required string FullName { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = [];
    }
}

