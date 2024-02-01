using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointment")]
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }

        [Column("doctorid")]
        public int DoctorId { get; set; }
        public Doctor Doctor {get; set;}

        [Column("patientid")]
        public int PatientId { get; set; }
        public Patient Patient {get; set;}

        public Appointment(){}
        public Appointment(int doctorid, int patientid, DateTime booking){
            Booking = booking;
            PatientId = patientid;
            DoctorId = doctorid;
        }

    }
}
