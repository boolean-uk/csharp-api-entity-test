using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }
        [Column("doctor_id")]

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [Column("patient_id")]

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
    public record AppointmentPayload(DateTime Booking, int DoctorId, int PatientId);
    public class AppointmentResponseDTO
    {
        public DateTime Booking { get; set; }
        public AppointmentPatientDTO Patient { get; set; }
        public AppointmentDoctorDTO Doctor { get; set; }
        public AppointmentResponseDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            Patient = new AppointmentPatientDTO(appointment.Patient);
            Doctor = new AppointmentDoctorDTO(appointment.Doctor);
        }
    }

    public class PatientAppointmentDTO
    {
        public DateTime Booking { get; set; }
        public AppointmentDoctorDTO Doctor { get; set; }
        
        public PatientAppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            Doctor = new AppointmentDoctorDTO(appointment.Doctor);
        }
    }

    public class DoctorAppointmentDTO
    {
        public DateTime Booking { get; set; }
        public AppointmentPatientDTO  Patient{get; set;}
        public DoctorAppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            Patient = new AppointmentPatientDTO(appointment.Patient);
        }
    }
}
