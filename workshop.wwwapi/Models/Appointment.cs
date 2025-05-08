using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    //appointments class
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }

        [Column("appointment_date")]
        public DateTime AppointmentDate { get; set; }

        [Column("appointment_is_online")]
        public bool IsOnline { get; set; }

        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

    }

    //DTO appointments
    public class AppointmentsResponseDTO
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsOnline { get; set; }

        public AppointmentsResponseDTO(Appointment appointment)
        {
            DoctorId = appointment.DoctorId;
            DoctorName = appointment.Doctor?.FullName;
            PatientId = appointment.PatientId;
            PatientName = appointment.Patient?.FullName;
            AppointmentDate = appointment.AppointmentDate;
            IsOnline = appointment.IsOnline;
            
        }
    }
}
