using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }        
        public int DoctorId { get; set; }   
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }                
        public Patient Patient { get; set; }
    }
}
