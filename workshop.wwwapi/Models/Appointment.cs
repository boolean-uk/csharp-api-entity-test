using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    public class Appointment
    {
        [Column("id")]          //By convention, a property named Id or <type name>Id will be configured as the primary key of an entity.
        [Key]
        public int Id { get; set; }
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

    }
}
