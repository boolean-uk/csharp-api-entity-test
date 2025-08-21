using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingl
    [Table("Appointments")]
    [PrimaryKey(nameof(DoctorId), nameof(PatientId))]
    public class Appointment
    {
        
        public DateTime Booking { get; set; }
        [Key, Column(Order = 0), ForeignKey("Doctors")]
        public int DoctorId { get; set; }
        [Key, Column(Order =1), ForeignKey("Patients")]
        public int PatientId { get; set; }



    }
}
