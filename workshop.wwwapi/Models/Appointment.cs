using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Column("doctor_id")]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Column("patient_id")]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Column("appointment_date")]
        public DateTime AppointmentDate { get; set; }

        [Column("type")]
        public AppointmentType Type { get; set; } = AppointmentType.Onsite;
        
        public AppointmentDto ToDto()
        {
            return new AppointmentDto
            {
                Doctor = Doctor.ToDataDto(),
                Patient = Patient.ToDataDto(),
                Time = AppointmentDate,
                Type = Type.ToString()
            };
        }
    }

    public class AppointmentCreateDto
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime Time { get; set; }
        public AppointmentType Type { get; set; } = AppointmentType.Onsite;
    }

    public struct AppointmentDto
    {
        public DoctorDataDto Doctor { get; set; }
        public PatientDataDto Patient { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }
    }

    public enum AppointmentType
    {
        Online,
        Onsite
    }
}
