using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("Appointments")]
    public class Appointment
    {
        [ForeignKey("Doctor")]
        [Column(Order = 1)]
        public int DoctorId { get; set; }

        [ForeignKey("Patient")]
        [Column(Order = 2)]
        public int PatientId { get; set; }

        [Column("datetime")]
        public DateTime Booking { get; set; }
    }
}
