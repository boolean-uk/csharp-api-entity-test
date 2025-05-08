using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointment")]
    public class Appointment
    {
      
        public int Id {get;set;}
        public DateTime Booking { get; set; }
        
        public int DoctorId { get; set; }
        
        public int PatientId { get; set; }
        [NotMapped]
        public Patient Patient {get;set;}
        [NotMapped]
        public Doctor Doctor{get;set;}

    }
}
