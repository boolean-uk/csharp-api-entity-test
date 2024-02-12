using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.DoctorModels;
using workshop.wwwapi.Models.PatientModels;
using workshop.wwwapi.Models.PrescriptionModels;

namespace workshop.wwwapi.Models.AppointmentModels
{
    public enum AppointmentType
    {
        InPerson,
        Online
    }

    [Table("appointments")]
    public class Appointment
    {
        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }

        [Column("booking")]
        public DateTime Booking { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        public AppointmentType Type { get; set; } 
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
