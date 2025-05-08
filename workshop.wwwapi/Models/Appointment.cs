using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }

        public string Type { get; set; }
     
        [ForeignKey("doctor_id")]
        public int DoctorId { get; set; }

        [ForeignKey("patient_id")]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }



    }
} 
