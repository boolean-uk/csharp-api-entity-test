using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Column("id")] 
        public int Id { get; set; }
        
        [Column("booking")] 
        public DateTime Booking { get; set; }
        
        [Column("doctorId")] 
        public int DoctorId { get; set; }
        
        [Column("patientId")] 
        public int PatientId { get; set; }

    }
}
