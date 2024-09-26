using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DTO
{
    public class AppointmentDoctor
    {
        [Column("bookingDate")]
        public DateTime Booking { get; set; }

        [ForeignKey("patient")]
        public int PatientId { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}
