using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.DTOs;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    [PrimaryKey(nameof(DoctorId), nameof(PatientId))]
    public class Appointment
    {
        [ForeignKey("doctor_id")]
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [ForeignKey("patient_id")]
        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [Column("booking_date")]
        public DateTime Booking { get; set; }

        public AppointmentDoctorDTO ToDoctorDTO()
        {
            return new AppointmentDoctorDTO { 
                PatientId = PatientId, 
                PatientName = Patient.FullName, 
                Booking = Booking };
        }

        public AppointmentPatientDTO ToPatientDTO()
        {
            return new AppointmentPatientDTO
            {
                DoctorId = DoctorId,
                DoctorName = Doctor.FullName,
                Booking = Booking
            };
        }

        public AppointmentResponseDTO ToResponseDTO()
        {
            return new AppointmentResponseDTO { 
                PatientId = PatientId,
                PatientName = Patient.FullName,
                DoctorId = DoctorId,
                DoctorName = Doctor.FullName,
                Booking = Booking };
        }
    }
}
