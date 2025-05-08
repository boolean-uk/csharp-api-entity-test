using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Column("bookingDate")]
        public DateTime Booking { get; set; }
        [ForeignKey("doctor")]
        [Column(Order = 1)]
        public int DoctorId { get; set; }
        [ForeignKey("patient")]
        [Column(Order = 2)]
        public int PatientId { get; set; }

        //[Column("prescription")]
        //[ForeignKey("prescriptionId")]
        //public int PrescriptionId { get; set; }

    }
}
