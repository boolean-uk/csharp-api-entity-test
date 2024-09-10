using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [PrimaryKey(nameof(DoctorId), nameof(PatientId))]
    public class Appointment
    {
        public DateTime Booking { get; set; }

        [Column(Order = 0)]
        public int DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        [Column(Order = 1)]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        //public int? MOPID { get; set; } 
        //[ForeignKey("MOPID")]
        //public MedicinOnPrescription? Prescription { get; set; }
        //public Location Location { get; set; }
    }
}
