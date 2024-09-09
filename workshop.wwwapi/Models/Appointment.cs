using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("Appointment")]
    public class Appointment
    {
        [Column("BookingTime")]
        public DateTime Booking { get; set; }

        [ForeignKey("Doctor_Id")]
        public int DoctorId { get; set; }

        [ForeignKey("Patient_Id")]
        public int PatientId { get; set; }

    }
}
