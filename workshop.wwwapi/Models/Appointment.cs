using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models
{
    public class Appointment
    {
        [Column("date", TypeName = "timestamp")]
        public DateTime Booking { get; set; }

        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        // Navigation properties
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
