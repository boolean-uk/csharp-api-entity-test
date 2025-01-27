using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Enums;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    public class Appointment
    {

        [Required]
        public DateTime Booking { get; set; }
        
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int PatientId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }

        public AppointmentType AppointmentType { get; set; }
    }
}
