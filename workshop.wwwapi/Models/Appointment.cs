using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Column("appointment_id")]
        public int Id { get; set; }

        [Column("appointment_type")]
        public AppointmentType AppointmentType { get; set; }

        [Column("booking_time")]
        public DateTime AppointmentDate { get; set; }


        [Column("fk_doctor_id")]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } 

        [Column("fk_patient_id")]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; } 

    }
    public class AppointmentDto
    {
        public DateTime AppointmentDate { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public AppointmentDto(Appointment appointment)
        {
            AppointmentDate = appointment.AppointmentDate;
            DoctorName = appointment.Doctor.FullName;
            PatientName = appointment.Patient.FullName;   
            AppointmentType = appointment.AppointmentType;
        }
    }

    public class AppointmentDoctorDto
    {
        public DateTime AppointmentDate { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public string PatientName { get; set; }
        public AppointmentDoctorDto(Appointment appointment)
        {
            AppointmentDate = appointment.AppointmentDate;
            PatientName = appointment.Patient.FullName;
            AppointmentType = appointment.AppointmentType;
        }
    }

    public class AppointmentPatientDto
    {
        public DateTime AppointmentDate { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public string DoctorName { get; set; }
        public AppointmentPatientDto(Appointment appointment)
        {
            AppointmentDate = appointment.AppointmentDate;
            DoctorName = appointment.Doctor.FullName;
            AppointmentType = appointment.AppointmentType;
        }
    }
    public class AppointmentPost
    {
        public DateTime AppointmentDate { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
    }
