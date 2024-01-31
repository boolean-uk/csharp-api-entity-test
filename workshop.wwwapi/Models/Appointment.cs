using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Column("bookings")]
        public string Booking { get; set; }
        

        // in memoty!!! No not add column
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
