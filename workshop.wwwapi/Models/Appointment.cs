using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {

        [Column("appointment_Id")]
        public int Id  { get; set; }
        [Column("booking_time")]
        public DateTime Booking { get; set; }


        public Doctor doctor { get; set; }

        [Column("doctor_Id")]
        public int DoctorId { get; set; }

        public Patient patient { get; set; }

        [Column("patient_Id")]
        public int PatientId { get; set; }

        [Column("perscription_Id")]
        public int PerscriptionId { get; set; }

        public Perscription Perscription { get; set; }



    }
}
