using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Column("appointmentDate")]
        private DateTime _booking;
        [Column("doctorId")]
        private int _doctorid;
        [Column("patientId")]
        private int _patientid;

        public DateTime Booking { get => _booking; set => _booking = value; }
        public int DoctorId { get => _doctorid; set => _doctorid = value; }
        public int PatientId { get => _patientid; set => _patientid = value; }
    }
}
