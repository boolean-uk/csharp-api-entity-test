using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{

    public enum AppointmentType
    {
        FaceToFace,
        Online
    }
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("bookings")]
        public string Booking { get; set; }
        [Column("appointment_type")]
        public AppointmentType TypeOfAppointent { get; set; }
        

        [Column("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        
        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
